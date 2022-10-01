using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int thisScene;
    [SerializeField] private AudioSource leftClick, rightClick;
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) leftClick.Play();
        if (Input.GetMouseButtonDown(1)) rightClick.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(thisScene);
    }
}
