using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public float randomdis;

    Coroutine destroyShieldOverTimeRoutine;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * Random.Range(0, randomdis);
        destroyShieldOverTimeRoutine = StartCoroutine(DestroyShieldOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    IEnumerator DestroyShieldOverTime()
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
