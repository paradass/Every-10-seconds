using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixText : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        Fall();
    }
    void Fall()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime*-1, 0);
        if (transform.position.y < -5) Destroy(gameObject);
    }
}
