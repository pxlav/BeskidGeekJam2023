using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScennary : MonoBehaviour
{
    public bool ismenuOn;
    public GameObject menuObj;

    private void Start()
    {
        ismenuOn = true;
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
