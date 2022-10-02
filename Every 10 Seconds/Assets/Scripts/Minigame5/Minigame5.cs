using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame5 : MonoBehaviour
{
    private static Minigame5 _instance;
    public static Minigame5 Instance => _instance;

    [SerializeField] private GameObject nextMinigame,popUp;
    bool control;
    int counter;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        transform.GetChild(1).gameObject.transform.position = new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.7f, 0.7f), transform.position.z);
        GameManager.Instance.minigame = 4;
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
            ExitPopUp();
        }
    }

    void NextPopUp()
    {
        GameManager.Instance.minigame = 2;
        GameManager.Instance.minigames[0].SetActive(true);
        Minigame1.Instance.nextMinigameOpenTime = 2;
        gameObject.SetActive(false);
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 1;
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
