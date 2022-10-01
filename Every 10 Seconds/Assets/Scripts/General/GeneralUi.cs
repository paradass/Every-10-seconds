using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralUi : MonoBehaviour
{
    [SerializeField] private int thisScene;

    public void Restart()
    {
        SceneManager.LoadScene(thisScene);
    }
}
