using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2 : MonoBehaviour
{
    private static Minigame2 _instance;
    public static Minigame2 Instance => _instance;

    [SerializeField] private GameObject nextMinigameObject;
    bool control;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        GameManager.Instance.minigame = 1;
        Invoke("OpenControl", 1);
        Invoke("BackToGame", 10);
    }
    private void OnDisable()
    {
        control = false;
        CancelInvoke("BackToGame");
    }

    void Update()
    {
        Control();
    }

    void OpenControl()
    {
        control = true;
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 0;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }

    void Control()
    {
        if (!control) return;
        if (Input.GetMouseButtonDown(0))
        {
            nextMinigameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            BackToGame();
        }
    }
}
