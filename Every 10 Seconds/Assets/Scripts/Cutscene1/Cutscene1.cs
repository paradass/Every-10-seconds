using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    [SerializeField] private float nextMinigameTime;
    [SerializeField] private GameObject spawnPoint,nextMinigame;
    [SerializeField] private GameObject[] matrixTexts;
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1);
        Invoke("NextMinigame", nextMinigameTime);
    }

    void Spawn()
    {
        GameObject matrix = Instantiate(matrixTexts[Random.Range(0, 2)], spawnPoint.transform.position, Quaternion.identity);
        matrix.transform.parent = transform;
    }

    void NextMinigame()
    {
        CancelInvoke("Spawn");
        nextMinigame.SetActive(true);
        gameObject.SetActive(false);
    }
}
