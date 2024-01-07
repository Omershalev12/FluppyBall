using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{
    public float speed;
    public bool left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -1)
        {
            left = false;
        }
        if (transform.position.x > 1)
        {
            left = true;
        }
        if (left == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (left == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
