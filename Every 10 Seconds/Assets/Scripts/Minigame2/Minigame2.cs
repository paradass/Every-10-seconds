using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2 : MonoBehaviour
{
    private static Minigame2 _instance;
    public static Minigame2 Instance => _instance;

    bool control;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.transform.position = new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.3f, 0.3f), transform.position.z);
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

    void Control()
    {
        if (!control) return;
        if (Input.GetMouseButtonDown(0))
        {
            control = false;
            Invoke("ExitPopUp", 0.2f);
        }
        if (Input.GetMouseButtonDown(1))
        {
            control = false;
            NextPopUp();
        }
    }

    void NextPopUp()
    {
        GameManager.Instance.minigame = 1;
        Minigame1.Instance.nextMinigameOpenTime = 2;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 0;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }

    void ExitPopUp()
    {
        GameManager.Instance.exitPopup = true;
        GameManager.Instance.minigame = 0;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
}
