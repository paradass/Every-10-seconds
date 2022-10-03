using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public float time;
    void Start()
    {
        Invoke("BackMenu", time);
    }

    void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

}
