using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame5 : MonoBehaviour
{
    private static Minigame5 _instance;
    public static Minigame5 Instance => _instance;

    [SerializeField] private GameObject fakeBackground,nextMinigame,popUp;
    bool control;
    int counter;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        transform.GetChild(0).gameObject.transform.position = new Vector3(Random.Range(-0.7f, 0.7f), 0, transform.position.z);
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
            NextMinigame();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ExitPopUp();
        }
    }

    void NextMinigame()
    {
        nextMinigame.SetActive(true);
        fakeBackground.SetActive(false);
        gameObject.SetActive(false);
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 3;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
    void ExitPopUp()
    {
        GameObject spawnedPopup = Instantiate(popUp, new Vector3(Random.Range(-1.5f, 0.7f), 0f, -2), Quaternion.identity);
        spawnedPopup.transform.parent = transform.GetChild(1);
        spawnedPopup.transform.position -= new Vector3(0, 0, 0.1f * counter);
        counter++;
        if (counter < 10) return;
        GameManager.Instance.exitPopup = true;
        GameManager.Instance.minigame = 0;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
}
