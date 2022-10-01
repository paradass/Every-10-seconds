using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minigame1 : MonoBehaviour
{
    private static Minigame1 _instance;
    public static Minigame1 Instance => _instance;

    [System.NonSerialized] public int score;
    [SerializeField] private Text scoreText,waveText,FirstEndText;
    [SerializeField] private Button restartButton;
    [SerializeField] private float waveStartTime;
    [SerializeField] private GameObject[] waves;
    [SerializeField] private GameObject allObjects;
    float waveTime;
    int waveIndex;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(SetWave());
        StartCoroutine(ShowWave());
    }

    private void Update()
    {
        ShowScore();
    }
    void ShowScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator SetWave()
    {
        if (waveIndex == 0) yield return new WaitForSeconds(0.1f);
        else yield return new WaitForSeconds(waveStartTime);
        waves[waveIndex].SetActive(true);

        if (waveIndex + 1 < waves.Length)
        {
            waveTime = waveStartTime;
            waveIndex++;
            StartCoroutine(SetWave());
        }
        else StartCoroutine(SetWave());
    }

    IEnumerator ShowWave()
    {
        yield return new WaitForSeconds(1);
        if (waveTime > 0) waveTime--;
        waveText.text = "Next wave: " + waveTime.ToString();
        StartCoroutine(ShowWave());
    }
    public void End()
    {
        StartCoroutine(FirstEnd());
    }
    public IEnumerator FirstEnd()
    {
        yield return new WaitForSeconds(0.5f);
        allObjects.SetActive(false);
        waveText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        FirstEndText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        FirstEndText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }
}
