using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    
    public GameObject m_PlayerPrefab;

    public SphereCollider m_SphereCollider;
    //�÷��̾�� �����̶� �ε����� �÷��̾� ���
    private void Start()
    {
        m_SphereCollider = GetComponent<SphereCollider>();
    }

    
}
