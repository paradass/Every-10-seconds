using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    Rigidbody2D rb;
    bool sagdanFirlat = true, soldanFirlat = true, asagidanFirlat = true, yukaridanFirlat = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 500);
        Application.targetFrameRate = 75;
    }
    void Update()
    {
        YonDegis();
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }

    void YonDegis()
    {
        if (transform.position.x > 2.6f && sagdanFirlat)
        {
            sagdanFirlat = false;
            soldanFirlat = true;
            rb.velocity *= new Vector2(-1, 1);
        }
        else if (transform.position.x < -2.6f && soldanFirlat)
        {
            soldanFirlat = false;
            sagdanFirlat = true;
            rb.velocity *= new Vector2(-1, 1);
        }
        if (transform.position.y > 5 && yukaridanFirlat)
        {
            yukaridanFirlat = false;
            asagidanFirlat = true;
            rb.velocity *= new Vector2(1, -1);
        }
        else if (transform.position.y < -5 && asagidanFirlat)
        {
            asagidanFirlat = false;
            yukaridanFirlat = true;
            rb.velocity *= new Vector2(1, -1);
        }
    }
}
