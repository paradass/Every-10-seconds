using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [System.NonSerialized] public float speed;
    void Start()
    {
        
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += new Vector3(0, Time.deltaTime * speed);
        if(transform.position.y > 1.3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Death();
            Destroy(gameObject);
        }
    }
}
