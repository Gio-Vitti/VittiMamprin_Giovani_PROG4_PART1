using UnityEngine;
using System.Collections;

public class spawnStain : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        transform.position = new Vector3(Random.Range(-4, 4), 0.1f, Random.Range(-4, 4));
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        spawn();
    }
}
