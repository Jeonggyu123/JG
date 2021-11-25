using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float m_SpawnRate = 1f;
    public GameObject m_MonsterPrefab;

    private Coroutine m_SpawnCoroutine;

    void Start()
    {
        EventManager.getInstance.EventDefinition("onGameStart", Spawn);
        EventManager.getInstance.EventDefinition("onGamePaused", StopSpawn);
    }

    void StopSpawn(object param)
    {
        StopCoroutine(m_SpawnCoroutine);
    }

    void Spawn(object param)
    {
        m_SpawnCoroutine = StartCoroutine(SpawnRoutine());

    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            print("»ý¼ºÁß");
            ObjectPoolManager.getInstance.Spawn("snowball", transform.position);
            
            yield return new WaitForSeconds(m_SpawnRate);
        }    
                
    }
}
