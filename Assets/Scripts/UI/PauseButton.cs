using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    private void Start()
    {
        EventManager.getInstance.EventDefinition("onGamePaused", OnGamePaused);
        EventManager.getInstance.EventDefinition("onGameStart", OnGameStart);
    }

    private void OnGameStart(object obj)
    {
        gameObject.SetActive(true);
    }

    public void ButtonDown()
    {
        EventManager.getInstance.Emit("onGamePaused", null);
    }

    void OnGamePaused(object param)
    {
        gameObject.SetActive(false);
    }

}
