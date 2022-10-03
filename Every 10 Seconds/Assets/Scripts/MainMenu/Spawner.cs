using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint, creditsText;
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
    }

    void Spawn()
    {
        GameObject matrix = Instantiate(creditsText, spawnPoint.transform.position, Quaternion.identity);
        matrix.transform.parent = transform;
    }
}
