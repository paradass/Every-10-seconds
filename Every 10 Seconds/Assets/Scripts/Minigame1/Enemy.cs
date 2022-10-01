using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed, stopTime,continueTime;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource explosionSound;
    bool movement = true;
    float x;
    void Start()
    {
        Invoke("FirstStop", stopTime);
        Invoke("Continue", continueTime);
        InvokeRepeating("RandomDirection", 0.2f, 0.2f);
    }

    void Update()
    {
        Movement();
    }

    void FirstStop()
    {
        movement = false;
    }

    void Continue()
    {
        movement = true;
    }
    void RandomDirection()
    {
        int random = Random.Range(0, 3);
        if (random == 0) x = 1;
        else if (random == 1) x = -1;
        else x = 0;
    }
    void Movement()
    {
        if (movement)
        {
            transform.position += new Vector3(x*Time.deltaTime,speed*Time.deltaTime*-1,0);
        }
        if (transform.position.y < -1.2f) Destroy(gameObject);
    }
    public void Death()
    {
        Minigame1.Instance.score += 1;
        explosionSound.Play();
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity),1);
        Destroy(gameObject, 0.1f);
    }
}
