using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 1;
    public float destroyTime;
    public float randomdis;


    Coroutine destroyObsOverTimeRoutine;
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.up * Random.Range(-randomdis, randomdis);
        destroyObsOverTimeRoutine = StartCoroutine(DestroyObsOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    IEnumerator DestroyObsOverTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }


}
