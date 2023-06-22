using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public GameScennary m_gameScenarry;
    public float speed;
    public float waitingTimer;
    private void Start()
    {
        speed = 0f;
    }
    private void Update()
    {
        if (m_gameScenarry.isgameStopped == true)
        {
            this.transform.Translate(speed, 0, 0);

            if (waitingTimer < 13)
            {
                waitingTimer += Time.deltaTime;
                if (waitingTimer > 13)
                {
                    speed = 0.005f;
                }
            }
        }
    }
}
