using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public int minigame = 0;
    [SerializeField] private int thisScene;
    [SerializeField] private AudioSource leftClick, rightClick;
    public GameObject[] minigames;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) leftClick.Play();
        if (Input.GetMouseButtonDown(1)) rightClick.Play();
    }
    public GameObject GetMinigameObject()
    {
        return minigames[minigame];
    }
    public GameObject GetNextMinigameObject()
    {
        return minigames[minigame+1];
    }
    public void Restart()
    {
        SceneManager.LoadScene(thisScene);
    }
}
