using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseScript : MonoBehaviour
{
    [SerializeField] Sprite mouse1;
    [SerializeField] Sprite mouse2;
    public codeBlockButton codeblocks;
    
    Vector2 mousepos;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().sprite = mouse1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<SpriteRenderer>().sprite = mouse2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = Vector2.right * 50 * Time.deltaTime;
        }
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, mousepos.y);
      
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
           if(GetComponent<SpriteRenderer>().sprite == mouse1 && codeblocks.GetComponent<SpriteRenderer>().sprite == codeblocks.sprite2)
            {
                Debug.Log("death");
            }
            if(GetComponent<SpriteRenderer>().sprite == mouse2 && codeblocks.GetComponent<SpriteRenderer>().sprite == codeblocks.sprite1)
            {
                Debug.Log("death");
            }
            if (collision.gameObject.tag == "wallaralik")
            {
                Debug.Log("death");
            }
            
        }
    }
    
    
}
