using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame7 : MonoBehaviour
{
    private static Minigame7 _instance;
    public static Minigame7 Instance => _instance;

    public GameObject self,nextMinigame;
    [SerializeField] float nextMinigameTime;
    [SerializeField] private GameObject[] waves;
    int waveIndex;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
        Invoke("NextMinigame", nextMinigameTime);
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(1);
        if(waveIndex < waves.Length)
        {
            waves[waveIndex].SetActive(true);
            waveIndex++;
            yield return new WaitForSeconds(5);
            StartCoroutine(SpawnWave());
        }
    }
    public void TryAgain()
    {
        GameManager.Instance.SpawnMinigame7();
    }
    void NextMinigame()
    {
        nextMinigame.SetActive(true);
        Destroy(gameObject);
    }
}
