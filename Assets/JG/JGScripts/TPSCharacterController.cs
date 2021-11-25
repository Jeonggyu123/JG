using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TPSCharacterController : MonoBehaviour
{
    // private float moveSpeed = 5.0f;   // ���ǵ�

    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
        Move();


        //var vec = new Vector3(horizontalInput, 0, vericalInput).normalized;

        //transform.rotation = Quaternion.LookRotation(vec);
        //transform.Translate(vec * (Time.deltaTime * m_fSpeed, Space.World);
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isMove", isMove);
        if(isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;
            transform.position += moveDir * Time.deltaTime * 10f;   //���ǵ�
        }
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized, Color.red);
        
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }
}
