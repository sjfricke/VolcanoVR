using UnityEngine;
using System.Collections;
using System;

public class movement : MonoBehaviour
{


    double x, y, z;
    double x2, y2, z2;
    CharacterController controller;
    // Use this for initialization
    void Start()
    {
       controller = GetComponent<CharacterController>();
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("test2");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            
       
        if (Input.GetMouseButton(0))
        {
            x = Math.Abs(Cardboard.Controller.transform.eulerAngles.x % 360);
            y = Math.Abs(Cardboard.Controller.transform.eulerAngles.y % 360);
            z = Math.Abs(Cardboard.Controller.transform.eulerAngles.z % 360);

            x2 = Math.Sin(y * (Math.PI / 180.0));
            y2 = Math.Sin(x * (Math.PI / 180.0)) * -1;
            z2 = ((Math.Cos(y * (Math.PI / 180.0))) * (Math.Cos(x * (Math.PI / 180.0))));


            float mult = 1;

            Vector3 move = new Vector3((float)x2 * mult , (float)y2 * mult, (float)z2 * mult );
            //controller.Move(move);
            transform.position += move;
        }
    }
}



