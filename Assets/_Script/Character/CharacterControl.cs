using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator anim;
    //Rigidbody control;
    CharacterController control;
     
    bool isMove;
    float inputMove;
    
    bool isRun = false;
    public float moveSpeed;
    public float runSpeed;
    public float jumpForce;
    public float turnSpeed = 0.1f;
    public float gravity;
    float turnSpeedVel;
    float throttle = 10;
    public int face;


    Vector3 direction = Vector3.zero;
    
    [Range(0, 1)] public float slide = 0.9f;

    void Start()
    {
        //control = GetComponent<Rigidbody>();
        control = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //status = GetComponent<playerStatus>();
    }// Start is called before the first frame update
    

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        //float faceDir = moveInput.normalized;
        Vector3 moveDir = new Vector3(moveInput, 0, 0);

        //Vector3 vInput = control.velocity;

        if (control.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //anim.SetTrigger("jump"); //ANIMATOR jump trigger
                moveDir.y = jumpForce;
            }

        }

        if (moveDir.magnitude >= 0.1f)
        {
            if(moveInput > 0 && transform.rotation.y != 90)
            {
                face = 1;
                direction = new Vector3(0, 90, 0);
                float rotation = Mathf.Lerp(transform.eulerAngles.y, direction.y, turnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            if(moveInput < 0 && transform.rotation.y != 270)
            {
                face = -1;
                direction = new Vector3(0, 270, 0);
                float rotation = Mathf.Lerp(transform.eulerAngles.y, direction.y, turnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }




        }



        moveDir.y += Physics.gravity.y * gravity * Time.deltaTime;
        control.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
