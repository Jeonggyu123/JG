using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_fSpeed = 1.0f;

    void Start()
    {
        
    }
    
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var vericalInput = Input.GetAxis("Vertical");
        var vec = new Vector3(horizontalInput, 0, vericalInput).normalized;

        transform.rotation = Quaternion.LookRotation(vec);
        transform.Translate(vec * (Time.deltaTime*m_fSpeed),Space.World);

        
    }

    public void Dead()
    {
        gameObject.SetActive(false);


    }
}
