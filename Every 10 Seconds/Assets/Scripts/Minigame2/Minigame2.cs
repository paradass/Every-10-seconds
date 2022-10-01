using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2 : MonoBehaviour
{
    private static Minigame2 _instance;
    public static Minigame2 Instance => _instance;

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
}
