using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public GameObject obs;
    public GameObject obs2;
    public GameObject score;
    public float creationTime;
    public float creationTime2;


    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, creationTime);
    }

    void Spawn()
    {
        Instantiate(obs, transform.position, Quaternion.identity);
    }

}
