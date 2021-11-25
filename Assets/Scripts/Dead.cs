using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    
    public GameObject m_PlayerPrefab;

    public SphereCollider m_SphereCollider;
    //ÇÃ·¹ÀÌ¾î¶û ´«µ¢ÀÌ¶û ºÎµúÈ÷¸é ÇÃ·¹ÀÌ¾î »ç¸Á
    private void Start()
    {
        m_SphereCollider = GetComponent<SphereCollider>();
    }

    
}
