using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] colors;
    [System.NonSerialized] public int color;
    void Start()
    {
        int random = Random.Range(0, 2);
        color = random;
        GetComponent<SpriteRenderer>().sprite = colors[random];
    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * -1, 0, 0);
        if (transform.position.x < -10) Destroy(gameObject);
    }
}
