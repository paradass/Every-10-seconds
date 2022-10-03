using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame7 : MonoBehaviour
{
    private static Minigame7 _instance;
    public static Minigame7 Instance => _instance;

    public GameObject self;
    [SerializeField] float nextSceneTime;
    [SerializeField] private GameObject[] waves;
    [SerializeField] private Sprite[] screns;
    int waveIndex;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
        StartCoroutine(NextScene());
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
        StopCoroutine(NextScene());
        GameManager.Instance.SpawnMinigame7();
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(nextSceneTime);
        transform.GetChild(2).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = screns[0];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = screns[1];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = screns[2];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = screns[3];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = screns[4];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = screns[5];
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(2);
    }
}
