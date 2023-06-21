using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameScennary : MonoBehaviour
{
    public bool ismenuOn;
    public GameObject menuObj;
    public GameObject firstCutScenesObj;
    public float cutScenesTimer;
    public bool canCutSceneShow;
    public bool isDied;
    public float dieTimer;
    public GameObject dieScreen;
    public GameObject sanityBar;
    public bool isgameStopped;

    private void Start()
    {
        ismenuOn = true;
        cutScenesTimer = 0;
        firstCutScenesObj.SetActive(false);
        canCutSceneShow = true;
        isDied = false;
        dieTimer = 0.0f;
        dieScreen.SetActive(false);
        sanityBar.SetActive(false);
    }

    private void Update()
    {
        if (ismenuOn == false && canCutSceneShow == false && isDied == false)
        {
            sanityBar.SetActive(true);
            isgameStopped = true;
        }else
        {
            isgameStopped = false;
        }
        if (ismenuOn == true)
        {
            sanityBar.SetActive(false);
            menuObj.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            menuObj.SetActive(false);
            Time.timeScale = 1;
            if (canCutSceneShow == true)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    cutScenesTimer = 32.9f;
                }
                firstCutScenesObj.SetActive(true);
                canCutSceneShow = true;
                cutScenesTimer += Time.deltaTime;

                if (cutScenesTimer >= 33)
                {
                    firstCutScenesObj.SetActive(false);
                    canCutSceneShow = false;

                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ismenuOn = !ismenuOn;
        }
        if(isDied == true)
        {
            dieScreen.SetActive(true);
            dieTimer += Time.deltaTime;
            if(dieTimer > 3.0f)
            {
                SceneManager.LoadScene(0);
            }
        }

    }
    public void PlayButton()
    {
        ismenuOn = false;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void YouDied()
    {
        isDied = true;
    }
}
