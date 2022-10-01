using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed,laserSpeed,laserTime;
    [SerializeField] private GameObject laser;
    [SerializeField] private AudioSource laserSound;
    float left, right;
    void Start()
    {
        InvokeRepeating("LaserShoot", laserTime, laserTime);
    }
    void Update()
    {
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
}
