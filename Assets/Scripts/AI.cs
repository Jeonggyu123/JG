using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_NavMeshAgent;
    [SerializeField]
    public Transform m_Target;


    private void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(m_Target)
        {
        m_NavMeshAgent.destination = m_Target.position;
        }
        else
        {
            m_NavMeshAgent.destination = transform.position;
        }
            



    }
}
