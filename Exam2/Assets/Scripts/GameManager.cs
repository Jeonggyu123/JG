using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager getInstance;

    public GameState m_State;

    private void Awake()
    {
        getInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_State = GameState.Ready;
        EventManager.getInstance.EventDefinition("onGameStart", OnGameStart);
        EventManager.getInstance.EventDefinition("onGameEnded", OnGameEnded);
        EventManager.getInstance.EventDefinition("onGamePaused", OnGamePaused);
    }

    void OnGameStart(object obj)
    {
        m_State = GameState.Playing;
    }

    void OnGamePaused(object obj)
    {
        m_State = GameState.Paused;
        
    }


    void OnGameEnded(object obj)
    {
        m_State = GameState.Ended;  
    }

}
