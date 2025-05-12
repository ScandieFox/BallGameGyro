using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    public Vector3 TargetRot;
    public int speed = 10;

   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        TargetRot = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        //TargetRot.y += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        TargetRot.x += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        TargetRot.z += Input.GetAxis("Horizontal") * Time.deltaTime * speed;



        // limite x axis
        if (TargetRot.x >= 25)
        {
            TargetRot.x = 25;
        }
        if(TargetRot.x <= -25)
        {
            TargetRot.x = -25;
        }
        // limite z axis
        if (TargetRot.z >= 25)
        {
            TargetRot.z = 25;
        }
        if (TargetRot.z <= -25)
        {
            TargetRot.z = -25;
        }

        /*
        if ((Input.GetAxis("Horizontal") > .2) && (CurrentRot.z <=10 || CurrentRot.z >=348))
        {
            transform.Rotate(0, 0, 1);
        }
        if ((Input.GetAxis("Horizontal") < .2) && (CurrentRot.z >=349 || CurrentRot.z <=11))
        {
            transform.Rotate(0, 0, -1);
        }
        if ((Input.GetAxis("Vertical") > .2) && (CurrentRot.z <=10 || CurrentRot.z >=348))
        {
            transform.Rotate(1, 0, 0);
        }
        if ((Input.GetAxis("Vertical") < .2) && (CurrentRot.z >=349 || CurrentRot.z <= 11))
        {
            transform.Rotate(-1, 0, 0);
        }*/
        transform.rotation =Quaternion.Euler( TargetRot);

    }
}
