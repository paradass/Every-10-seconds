using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed,laserSpeed,laserTime;
    [SerializeField] private GameObject laser;
    [SerializeField] private AudioSource laserSound,deadSound;
    float left, right;
    bool dead;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("LaserShoot", laserTime, laserTime);
    }
    void Update()
    {
        if (dead) return;
        Control();
    }

    void Control()
    {
        if (transform.position.x > -2.6f) left = Input.GetAxisRaw("Fire1") * -1;
        else left = 0;
        if (transform.position.x < 1.6f) right = Input.GetAxisRaw("Fire2");
        else right = 0;

        transform.position += new Vector3((left + right) * Time.deltaTime * speed, 0, 0);
    }
    void LaserShoot()
    {
        Instantiate(laser, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity).GetComponent<Laser>().speed = laserSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            dead = true;
            animator.SetBool("dead", true);
            deadSound.Play();
            Destroy(gameObject, 0.4f);
        }
    }
}
