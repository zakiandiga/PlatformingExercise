using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject player;
    CharacterControl control;
    bool isControl = true; //Set to false for cutscene!
    Vector3 currentPos;
    public Vector3 offset;
    public float followSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //currentPos = transform.position;
        control = player.GetComponent<CharacterControl>();
    }

    void LateUpdate()
    {
        Vector3 targetPos = player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        transform.position = smoothPos;
        //transform.LookAt(player.transform.position);
        /*currentPos = transform.position;
        Vector3 targetPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        Vector3 smoothPos = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
        transform.position = smoothPos;*/

        /*
        if (control.face == 1)
        {
            currentPos = transform.position;
            Vector3 targetPos = new Vector3(player.transform.position.x + 2, transform.position.y, transform.position.z);
            Vector3 smoothPos = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
            transform.position = smoothPos;
        }
        if (control.face == -1)
        {
            currentPos = transform.position;
            Vector3 targetPos = new Vector3(player.transform.position.x - 2, transform.position.y, transform.position.z);
            Vector3 smoothPos = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
            transform.position = smoothPos;
        }
        */
    }
}
