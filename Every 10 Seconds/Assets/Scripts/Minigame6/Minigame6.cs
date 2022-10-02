using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame6 : MonoBehaviour
{
    private static Minigame6 _instance;
    public static Minigame6 Instance => _instance;
    [SerializeField] private GameObject nextMinigame,end;
    [SerializeField] private Sprite[] phase,dotSprites;
    [SerializeField] private GameObject[] dots;
    [SerializeField] private AudioSource passwordMusic,trueSound,falseSound;
    int tryCount,passwordPhase=1;
    bool control,one,two,three,four;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        StartCoroutine(Edit());
    }

    void Update()
    {
        Control();
    }
    
    IEnumerator Edit()
    {
        yield return new WaitForSeconds(1);
        passwordMusic.Play();
        yield return new WaitForSeconds(2);
        control = true;
    }

    void Control()
    {
        //sol sað sol sol
        if (!control) return;
        if(passwordPhase == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                one = true;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[0];
                passwordPhase++;
            }
            if (Input.GetMouseButtonDown(1))
            {
                one = false;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[1];
                passwordPhase++;
            }
        }
        else if (passwordPhase == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                two = false;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[0];
                passwordPhase++;
            }
            if (Input.GetMouseButtonDown(1))
            {
                two = true;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[1];
                passwordPhase++;
            }
        }
        else if (passwordPhase == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                three = true;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[0];
                passwordPhase++;
            }
            if (Input.GetMouseButtonDown(1))
            {
                three = false;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[1];
                passwordPhase++;
            }
        }
        else if (passwordPhase == 4)
        {
            if (Input.GetMouseButtonDown(0))
            {
                four = true;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[0];
                passwordPhase++;
                PasswordControl();
            }
            if (Input.GetMouseButtonDown(1))
            {
                four = false;
                dots[passwordPhase - 1].SetActive(true);
                dots[passwordPhase - 1].GetComponent<SpriteRenderer>().sprite = dotSprites[1];
                passwordPhase++;
                PasswordControl();
            }
        }
    }

    void PasswordControl()
    {
        if(one && two && three && four)
        {
            trueSound.Play();
            Invoke("NextMinigame", 1);
        }
        else
        {
            tryCount++;
            GetComponent<SpriteRenderer>().sprite = phase[tryCount];
            ResetPasswordTry();
            falseSound.Play();
            control = false;
            Invoke("TryAgain", 1);
        }
    }

    void NextMinigame()
    {
        nextMinigame.SetActive(true);
        gameObject.SetActive(false);
    }

    void TryAgain()
    {
        if(tryCount >= 3)
        {
            end.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            control = true;
        }
    }

    void ResetPasswordTry()
    {
        one = false;
        two = false;
        three = false;
        four = false;
        passwordPhase = 1;
        foreach(GameObject dot in dots)
        {
            dot.SetActive(false);
        }
    }
}
