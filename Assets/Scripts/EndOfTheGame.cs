using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EndOfTheGame : MonoBehaviour
{
    public bool canEndTheGame;

    private void Start()
    {
        canEndTheGame = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canEndTheGame = true;
        }
    }
    private void Update()
    {
        if (canEndTheGame == true)
        {
            EndTheGame();
        }
    }
    public void EndTheGame()
    {
        Debug.Log("KONIEC GRYYYYYYY");
    }
}
