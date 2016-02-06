using UnityEngine;
using System.Collections;

public class onCollison : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("test2");
    }
}
