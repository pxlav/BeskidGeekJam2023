using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScennary : MonoBehaviour
{
    public bool ismenuOn;
    public GameObject menuObj;
    public GameObject firstCutScenesObj;
    public float cutScenesTimer;
    public bool canCutSceneShow;

    private void Start()
    {
        ismenuOn = true;
        cutScenesTimer = 0;
        firstCutScenesObj.SetActive(false);
        canCutSceneShow = true;
    }

    private void Update()
    {
        if (ismenuOn == true)
        {
            menuObj.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            menuObj.SetActive(false);
            Time.timeScale = 1;
            if (canCutSceneShow == true)
            {
                firstCutScenesObj.SetActive(true);
                canCutSceneShow = true;
                cutScenesTimer += Time.deltaTime;
                if (cutScenesTimer >= 9)
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

    }
    public void PlayButton()
    {
        ismenuOn = false;
        
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
