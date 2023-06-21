using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public GameObject leftPlayer;
    public GameObject rightPlayer;
    public GameObject frontPlayer;
    public bool isLeft;
    public int wichJump;
    public bool isHiding;
    public float sanityValue;
    public GameScennary m_gameScennary;
    public Slider sanitySlider;
    public bool isMinussanity;
    public bool canAddsanity;
    void Start()
    {
        rightPlayer.SetActive(false);
        isHiding = false;
        sanityValue = 100;
        isMinussanity = true;
        canAddsanity = false;
    }

    void Update()
    {
        //sanity
        sanitySlider.value = sanityValue / 100;
        if (canAddsanity == true)
        {
            sanityValue += 0.01f;
        }
        if (isMinussanity == true)
        {
            sanityValue -= 0.007f;
        }
        if (sanityValue > 90 && sanityValue == 100)
        {
            speed = 5.5f;
        }
        if (sanityValue > 70 && sanityValue == 80)
        {
            speed = 4f;
        }
        if (sanityValue > 50 && sanityValue == 70)
        {
            speed = 3.5f;
        }
        if (sanityValue > 30 && sanityValue == 50)
        {
            speed = 3f;
        }
        if (sanityValue > 10 && sanityValue == 30)
        {
            speed = 2.5f;
        }
        if (sanityValue < 10)
        {
            speed = 2f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHiding = !isHiding;
        }
        if (isHiding == true)
        {
            PlayerHiding();
        }
        //if (m_menu.isOn == false)
        //{
        if (Input.GetKey(KeyCode.A) && !Input.GetMouseButton(0))
        {
            leftPlayer.SetActive(true);
            rightPlayer.SetActive(false);
            frontPlayer.SetActive(false);
            isLeft = true;
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetMouseButton(0))
        {
            leftPlayer.SetActive(false);
            rightPlayer.SetActive(true);
            frontPlayer.SetActive(false);
            isLeft = false;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            leftPlayer.SetActive(false);
            rightPlayer.SetActive(false);
            frontPlayer.SetActive(true);
        }

        //}
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);
    }
    public void PlayerHiding()
    {
        Debug.Log("Hideee");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainEnemy")
        {
            m_gameScennary.YouDied();
        }
        if (collision.tag == "SanityFlies")
        {
            canAddsanity = true;
            isMinussanity = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SanityFlies")
        {
            canAddsanity = false;
            isMinussanity = true;
        }
    }
}