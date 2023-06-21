using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheGame : MonoBehaviour
{
    public bool canEndTheGame;
    public float endTimer;
    public GameObject endSceneObj;

    private void Start()
    {
        endSceneObj.SetActive(false);
        canEndTheGame = false;
        endTimer = 5.0f;
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
            endSceneObj.SetActive(true);
            endTimer -= Time.deltaTime;
            if (endTimer <= 0)
            {
                EndTheGame();
            }
        }
    }
    public void EndTheGame()
    {
        Debug.Log("KONIEC GRYYYYYYY");
        SceneManager.LoadScene(0);
    }
}
