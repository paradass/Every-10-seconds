using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3 : MonoBehaviour
{
    private static Minigame3 _instance;
    public static Minigame3 Instance => _instance;

    [SerializeField] private GameObject nextMinigameObject;
    bool control;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        GameManager.Instance.minigame = 2;
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

    void Control()
    {
        if (!control) return;
        if (Input.GetMouseButtonDown(0))
        {
            control = false;
            Invoke("NextPopUp", 0.2f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            control = false;
            Invoke("NextPopUp", 0.2f);
        }
    }

    void NextPopUp()
    {
        nextMinigameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 1;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
}
