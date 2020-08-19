using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControlrb : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public GameObject groundChecker;
    bool isMove;
    float inputMove;

    bool isRun = false;
    public float moveSpeed;
    public float runSpeed;

    public bool isGrounded;
    public float jumpForce;
    public float turnSpeed;
    GroundCheck gc;

    float turnSpeedVel;
    float throttle = 10;
    public int face;

    public float jumpSlot = 1;
    Vector3 direction = Vector3.zero;

    public KeyCode jump;

    [Range(0, 1)] public float slide = 0.9f;// Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gc = groundChecker.GetComponent<GroundCheck>();

    }


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 v = rb.velocity;
        print(rb.velocity);

        //Basic Move (Left & Right)
        if (h > 0)
        {
            rb.velocity = new Vector3(h * (moveSpeed + runSpeed), v.y, 0);
            direction = new Vector3(0, 90, 0);
            float rotation = Mathf.Lerp(transform.eulerAngles.y, direction.y, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
        if (h < 0)
        {
            rb.velocity = new Vector3(h * (moveSpeed + runSpeed), v.y, 0);
            direction = new Vector3(0, 270, 0);
            float rotation = Mathf.Lerp(transform.eulerAngles.y, direction.y, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
        if (h == 0)
        {
            rb.velocity = new Vector3(v.x * slide, v.y, 0);
        }

        //Jump
        if (gc.isGrounded == true)
        {
            if (Input.GetAxisRaw("Jump") != 0)
            {
                
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //gc.isGrounded = false;
                //jumpSlot -= 1;
            }

   
        }

    }
}
