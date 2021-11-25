using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallower : MonoBehaviour
{
    //public Transform m_Player;

    [SerializeField]
    float m_HowLongWillYouGoFirst = 5;

    public GameObject m_Player;
    public float offsetX;
    public float offsetY;
    public float offsetZ;


    void Start()
    {
        //m_Player = GameObject.FindGameObjectWithTag("Player").transform;
      
        

    }

    void Update()
    {

        Vector3 FixedPos = new Vector3(m_Player.transform.position.x + offsetX, m_Player.transform.position.y + offsetY, m_Player.transform.position.z + offsetZ);

        transform.position = FixedPos;

        /*Vector3 WantMoveVector = new Vector3(m_Player.transform.position.x+m_HowLongWillYouGoFirst, m_Player.transform.position.y + m_HowLongWillYouGoFirst, m_Player.transform.position.z);

        transform.position = WantMoveVector;*/

    }
}
