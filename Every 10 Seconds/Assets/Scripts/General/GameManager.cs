using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public int minigame = 0;
    [System.NonSerialized] public bool exitPopup;
    [SerializeField] private int thisScene;
    [SerializeField] private AudioSource leftClick, rightClick;
    [SerializeField] GameObject fakeBackgorund, fakeShip, fakeEnemy;
    public GameObject[] minigames;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) leftClick.Play();
        if (Input.GetMouseButtonDown(1)) rightClick.Play();
    }
    public GameObject GetMinigameObject()
    {
        return minigames[minigame];
    }
    public GameObject GetNextMinigameObject()
    {
        return minigames[minigame+1];
    }
    public void Restart()
    {
        SceneManager.LoadScene(thisScene);
    }
    public void CreateFakeObjects()
    {
        fakeBackgorund.SetActive(true);
        fakeShip.SetActive(true);
        fakeShip.transform.position = GameObject.Find("Ship").transform.position;
        var enemys = GameObject.FindObjectsOfType<Enemy>();
        foreach(var enemy in enemys)
        {
            Instantiate(fakeEnemy, enemy.transform.position, Quaternion.identity);
        }
    }
    public void DeleteFakeObjects()
    {
        fakeBackgorund.SetActive(false);
        fakeShip.SetActive(false);
        GameObject[] fakes = GameObject.FindGameObjectsWithTag("Fake");
        foreach(GameObject fake in fakes)
        {
            fake.SetActive(false);
        }
    }
    public void SpawnMinigame7()
    {
        Destroy(Minigame7.Instance.gameObject);
        GameObject minigame7 = Instantiate(minigames[8], new Vector3(-0.47f, 0.11f, -2), Quaternion.identity);
    }
}
