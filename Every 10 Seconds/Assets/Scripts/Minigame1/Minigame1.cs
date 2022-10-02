using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minigame1 : MonoBehaviour
{
    private static Minigame1 _instance;
    public static Minigame1 Instance => _instance;
    [SerializeField] private float waveStartTime,nextMinigameOpenTime;
    [System.NonSerialized] public int score;
    [SerializeField] private Text scoreText, waveText, FirstEndText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject allObjects,waveParentObject;
    [SerializeField] private GameObject[] waves;
    float waveTime;
    int waveIndex;
    bool stopped;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        waves = new GameObject[waveParentObject.transform.childCount];
        for(int i = 0;i < waveParentObject.transform.childCount; i++)
        {
            waves[i] = waveParentObject.transform.GetChild(i).gameObject;
        }
        StartCoroutine(SetWave());
        StartCoroutine(ShowWave());
        Invoke("NextMinigameOpen", nextMinigameOpenTime);
    }
    private void OnDisable()
    {
        stopped = true;
    }
    private void OnEnable()
    {
        if (!stopped) return;
        waveTime = 10;
        StartCoroutine(SetWave());
        StartCoroutine(ShowWave());
        if (GameManager.Instance.exitPopup) StartCoroutine(SecondEnd());
        else Invoke("NextMinigameOpen", nextMinigameOpenTime);
        stopped = false;
        GameManager.Instance.DeleteFakeObjects();
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
        waveText.text = "Next wave: " + waveTime.ToString();
        yield return new WaitForSeconds(1);
        if (waveTime > 0) waveTime--;
        StartCoroutine(ShowWave());
    }
    public void End()
    {
        StartCoroutine(FirstEnd());
    }
    IEnumerator FirstEnd()
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

    IEnumerator SecondEnd()
    {
        yield return new WaitForSeconds(10);
        allObjects.SetActive(false);
        waveText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        FirstEndText.gameObject.SetActive(true);
        FirstEndText.text = "You Win!";
        yield return new WaitForSeconds(3f);
        FirstEndText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    void NextMinigameOpen()
    {
        GameManager.Instance.CreateFakeObjects();
        GameObject nextMinigame = GameManager.Instance.GetNextMinigameObject();
        nextMinigame.SetActive(true);
        gameObject.SetActive(false);
    }
}
