using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.J));       // J키누르면 Jump 활성화
        {                                                   
            animator.SetBool("isjump", true);           
        }
        /*
         if (Input.GetKeyDown(KeyCode.J)) ;       // J키누르면 Jump 활성화
        {
            animator.SetBool("isjump", false);
        }
        */
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);
        animator.SetBool("isWalk", moveVector.magnitude > 0);

        transform.Translate(new Vector3(moveX, 0f, moveZ).normalized * Time.deltaTime * 1f);
    }
}
