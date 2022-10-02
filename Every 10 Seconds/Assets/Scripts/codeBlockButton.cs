using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeBlockButton : MonoBehaviour
{
    [SerializeField] int randomint;
    public Sprite sprite1;
    public Sprite sprite2;
    void Start()
    {
        randomint = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(randomint == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite1; 
        }
        if(randomint == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sprite2;
        }
    }
    
}
