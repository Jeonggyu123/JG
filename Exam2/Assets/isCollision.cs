using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print("����ܾ�");

        Player player = collision.collider.GetComponent<Player>();

        if (player != null)
        {
            player.Dead();
        }
    }

}
