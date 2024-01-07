using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plusFiveController : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public float randomdis;

    Coroutine destroyInvOverTimeRoutine;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * Random.Range(0, randomdis);
        destroyInvOverTimeRoutine = StartCoroutine(DestroyInvOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    IEnumerator DestroyInvOverTime()
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
