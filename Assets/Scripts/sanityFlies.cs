using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanityFlies : MonoBehaviour
{
    public Animator particlessAnimator;
    public float lifeTime;
    public bool isEnd;
    public bool isPlayer;
    public float destroyTimer;
    private void Start()
    {
        destroyTimer = 5.0f;
        lifeTime = 3.5f;
        particlessAnimator.Play("idle");
    }

    private void Update()
    {
        if (isEnd == true)
        {
            particlessAnimator.Play("end");
            destroyTimer -= Time.deltaTime;
            if(destroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            particlessAnimator.Play("idle");
        }
        if (lifeTime <= 0)
        {
            isEnd = true;
        }
        if(isPlayer == true)
        {
            lifeTime -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isPlayer = false;
        }
    }
}
