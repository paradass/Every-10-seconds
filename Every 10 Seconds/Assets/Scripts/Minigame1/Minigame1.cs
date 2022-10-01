using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minigame1 : MonoBehaviour
{
    private static Minigame1 _instance;
    public static Minigame1 Instance => _instance;

    [System.NonSerialized] public int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private float waveStartTime;
    [SerializeField] private GameObject[] waves;
    int waveIndex;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(SetWave());
    }

    private void Update()
    {
        ShowScore();
    }

    IEnumerator SetWave()
    {
        if(waveIndex == 0) yield return new WaitForSeconds(2);
        else yield return new WaitForSeconds(waveStartTime);
        waves[waveIndex].SetActive(true);

        if (waveIndex + 1 < waves.Length)
        {
            waveIndex++;
            StartCoroutine(SetWave());
        }
        else StartCoroutine(SetWave());
    }
    void ShowScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
