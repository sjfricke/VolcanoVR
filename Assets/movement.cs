using UnityEngine;
using System.Collections;
using System;

public class movement : MonoBehaviour
{


    double x, y, z;
    double x2, y2, z2;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            x = Math.Abs(Cardboard.Controller.transform.eulerAngles.x % 360);
            y = Math.Abs(Cardboard.Controller.transform.eulerAngles.y % 360);
            z = Math.Abs(Cardboard.Controller.transform.eulerAngles.z % 360);

            x2 = Math.Sin(y * (Math.PI / 180.0));
            y2 = Math.Sin(x * (Math.PI / 180.0)) * -1;
            z2 = ((Math.Cos(y * (Math.PI / 180.0))) * (Math.Cos(x * (Math.PI / 180.0))));

           


            Vector3 move = new Vector3((float)x2 / 2, (float)y2 / 2, (float)z2 / 2);

            transform.position += move;
        }
    }
}



