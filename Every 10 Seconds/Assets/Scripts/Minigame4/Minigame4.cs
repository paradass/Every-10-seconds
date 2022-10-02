using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame4 : MonoBehaviour
{
    private static Minigame4 _instance;
    public static Minigame4 Instance => _instance;

    [SerializeField] private GameObject noButton;
    [SerializeField] private Sprite[] noButtonAnimations;
    int fillingCounter;
    bool control;
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        transform.GetChild(1).gameObject.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), transform.position.z);
        GameManager.Instance.minigame = 1;
        Invoke("OpenControl", 1);
        Invoke("BackToGame", 10);
        fillingCounter = 0;
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
            NextPopUp();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //control = false;
            //NextPopUp();
            StartCoroutine(EnterNoButton());
        }
        if (Input.GetMouseButtonUp(1))
        {
            StopCoroutine(EnterNoButton());
        }
    }

    IEnumerator EnterNoButton()
    {
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[0];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[1];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[2];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[3];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[4];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[5];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[6];
        yield return new WaitForSeconds(0.05f);
        noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[7];
        yield return new WaitForSeconds(0.05f);
        fillingCounter++;
        if(fillingCounter >= 3)
        {
            noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[8];
            yield return new WaitForSeconds(0.05f);
            noButton.GetComponent<SpriteRenderer>().sprite = noButtonAnimations[9];
            yield return new WaitForSeconds(0.05f);
            ExitPopUp();
        }
        else
        {
            StopCoroutine(EnterNoButton());
        }
    }

    void NextPopUp()
    {
        GameManager.Instance.minigame = 3;
        Minigame1.Instance.nextMinigameOpenTime = 2;
        GameManager.Instance.minigames[0].SetActive(true);
        gameObject.SetActive(false);
    }
    void BackToGame()
    {
        GameManager.Instance.minigame = 2;
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
