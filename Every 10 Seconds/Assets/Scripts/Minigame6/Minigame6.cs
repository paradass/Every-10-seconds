using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame6 : MonoBehaviour
{
    private static Minigame6 _instance;
    public static Minigame6 Instance => _instance;
    [SerializeField] private Sprite[] phase,dotSprites;
    [SerializeField] private GameObject[] dots;
    [SerializeField] private AudioSource passwordMusic,clickSound,trueSound,falseSound;
    int tryCount = 3,passwordPhase;
    bool control,one,two,three,four;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void StartOrWaitTrying(bool start)
    {
        if (start) control = true;
        else control = false;
    }

    void ResetPasswordTry()
    {
        one = false;
        two = false;
        three = false;
        four = false;
        passwordPhase = 0;
        foreach(GameObject dot in dots)
        {
            dot.SetActive(false);
        }
    }
}
