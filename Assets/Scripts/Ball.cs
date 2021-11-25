using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public GameObject m_PlayerPrefab;

    

    private void Update()
    {
        Vector3 PlayerPositoin = m_PlayerPrefab.transform.position;


        RotateForTarget(PlayerPositoin);
    }
        

    void RotateForTarget(Vector3 targetPos)
    {
        Vector3 MyPos = transform.position;

        Vector3 AimDir = (targetPos - MyPos).normalized;

        float Angle = Mathf.Atan2(AimDir.y, AimDir.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, Angle);
    }




}
