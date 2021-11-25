using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public void GameStart()
    {
        EventManager.getInstance.Emit("onGameStart", null);

            
    }
}
