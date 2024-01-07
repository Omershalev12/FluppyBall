using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour
{
    public float speed = 1;
    public float destroyTime;
    public float randomdis;

    Coroutine destroyStarOverTimeRoutine;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * Random.Range(0, randomdis);
        destroyStarOverTimeRoutine = StartCoroutine(DestroyStarOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Rotate(0, 60 * Time.deltaTime, 0 );
    }

    IEnumerator DestroyStarOverTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
