using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End3 : MonoBehaviour
{
    [SerializeField] private Sprite[] cutScene;
    [SerializeField] private GameObject restartButton,fakeMinigame;
    void Start()
    {
        StartCoroutine(End3Control());
    }

    IEnumerator End3Control()
    {
        fakeMinigame.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[0];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[1];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[2];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[3];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[4];
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().sprite = cutScene[5];
        yield return new WaitForSeconds(2f);
        restartButton.SetActive(true);
    }
}
