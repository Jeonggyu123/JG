using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    void Start()
    {
        EventManager.getInstance.EventDefinition("onGameStart", OnGameStarted);
        EventManager.getInstance.EventDefinition("onGamePaused", OnGamePaused);
    }


    void OnGameStarted(object param)
    {
        gameObject.SetActive(false);
    }
       
    void OnGamePaused(object obj)
    {
        gameObject.SetActive(true);     
    }
}
