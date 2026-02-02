using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
