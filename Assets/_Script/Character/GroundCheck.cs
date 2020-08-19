using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject player;
    //CharControlrb control;
    public bool isGrounded;

    void Start()
    {
        //control = player.GetComponent<CharControlrb>();
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }

    void OnTriggerEnter(Collider col)
    {
        //Landing GroundCheck
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            print("Grounded");
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
            print("NOT grounded");
        }
    }
    
}
