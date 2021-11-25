using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    private void OnEnable()
    {        
        Invoke("Dead",3);
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }

}
