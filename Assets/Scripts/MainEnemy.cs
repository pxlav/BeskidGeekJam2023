using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public GameScennary m_gameScenarry;
    public float speed;
    private void Update()
    {
        if (m_gameScenarry.isgameStopped == true)
        {
            this.transform.Translate(speed, 0, 0);
        }
    }
}
