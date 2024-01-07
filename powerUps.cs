using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public GameObject invisibility;  
    public GameObject star;   
    public GameObject five;   
    public GameObject shield;
    public float creationTimeInv;
    public float firstCreationInv;
    public float firstCreationStar;
    public float creationTimeStar;
    public float firstCreationFive;
    public float creationTimeFive;
    public float creationTimeShield;
    public float firstCreationShield;


    Rigidbody rb;
    BoxCollider boxcollider;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("invisible", firstCreationInv, creationTimeInv);
        InvokeRepeating("Star", firstCreationStar, creationTimeStar);
        InvokeRepeating("Five", firstCreationFive, creationTimeFive);
        InvokeRepeating("Shield", firstCreationShield, creationTimeShield);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void invisible()
    {
        Instantiate(invisibility, transform.position, Quaternion.identity);
    }
    
    void Star()
    {
        Instantiate(star, transform.position, Quaternion.identity);
    }

    void Five()
    {
        Instantiate(five, transform.position, Quaternion.identity);
    }

    void Shield()
    {
        Instantiate(shield, transform.position, Quaternion.identity);
    }
}
