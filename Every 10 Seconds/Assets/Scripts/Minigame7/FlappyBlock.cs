using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBlock : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * -1, 0, 0);
        if (transform.position.x < -10) Destroy(gameObject);
    }
}
