using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerController2D : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public GameObject leftPlayer;
    public GameObject rightPlayer;
    public GameObject frontPlayer;
    public bool isLeft;
    public int wichJump;
    public float sanityValue;
    public GameScennary m_gameScennary;
    public Slider sanitySlider;
    public bool isMinussanity;
    public bool canAddsanity;
    public GameObject walkingAudio;
    public GameObject sanityLow;
    public GameObject sanityLow2;
    public GameObject sanityLow3;
    public GameObject sanityUp;
    public RawImage sanityVignette;
    public bool isPlayerHidden;
    public bool hidden;
    public GameObject hiddenObj;
    void Start()
    {
        rightPlayer.SetActive(false);
        sanityValue = 100;
        isMinussanity = true;
        canAddsanity = false;
        walkingAudio.SetActive(false);
        sanityLow.SetActive(false);
        sanityLow2.SetActive(false);
        sanityLow3.SetActive(false);
        sanityVignette.rectTransform.localScale = new Vector3(15, 15, 15);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
        if (m_gameScennary.isgameStopped == true)
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
            if (sanityValue < 75)
            {
                sanityLow.SetActive(true);
                sanityVignette.rectTransform.localScale = new Vector3(13, 13, 13);
            }
            if (sanityValue < 50)
            {
                sanityLow2.SetActive(true);
                sanityVignette.rectTransform.localScale = new Vector3(9, 9, 9);
            }
            if (sanityValue < 30)
            {
                sanityLow3.SetActive(true);
                sanityVignette.rectTransform.localScale = new Vector3(7, 7, 7);

            }
            if (Input.GetKey(KeyCode.A) && !Input.GetMouseButton(0))
            {
                leftPlayer.SetActive(true);
                rightPlayer.SetActive(false);
                walkingAudio.SetActive(true);
                frontPlayer.SetActive(false);
                isLeft = true;
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetMouseButton(0))
            {
                leftPlayer.SetActive(false);
                rightPlayer.SetActive(true);
                walkingAudio.SetActive(true);
                frontPlayer.SetActive(false);
                isLeft = false;
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                leftPlayer.SetActive(false);
                rightPlayer.SetActive(false);
                frontPlayer.SetActive(true);
                walkingAudio.SetActive(false);
            }
            if(hiddenObj != null)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    hidden = !hidden;
                }
            }
            if(hidden == true)
            {
                Debug.Log("skryty");
            }else
            {
                Debug.Log("niekryty");
            }

        }
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MainEnemy")
        {
            m_gameScennary.YouDied();

        }
        if (collision.tag == "SanityFlies")
        {
            sanityUp.SetActive(true);
            canAddsanity = true;
            isMinussanity = false;
        }
        if(collision.tag == "HidingObject")
        {
            hiddenObj = collision.gameObject;
            isPlayerHidden = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SanityFlies")
        {
            sanityUp.SetActive(false);
            canAddsanity = false;
            isMinussanity = true;
        }
        if (collision.tag == "HidingObject")
        {
            hiddenObj = null;
            isPlayerHidden = false;
        }
    }
}