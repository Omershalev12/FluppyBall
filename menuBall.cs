using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBall : MonoBehaviour
{
    public float power;

    public Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bottom")
        {
            rb.velocity += Vector3.up * power;
        }
    }
}
