using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Sprite[] forms;
    Vector2 mousePos;
    int color;

    void Update()
    {
        Movement();
        ColorChange();
    }

    void ColorChange()
    {
        if (Input.GetMouseButtonDown(0))
        {
            color = 0;
            GetComponent<SpriteRenderer>().sprite = forms[0];
        }
        if (Input.GetMouseButtonDown(1))
        {
            color = 1;
            GetComponent<SpriteRenderer>().sprite = forms[1];
        }
    }
    void Movement()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, mousePos.y);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        if(transform.position.y > 1.1f)
        {
            transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
        }
        else if(transform.position.y < -1f)
        {
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<NormalBlock>(out NormalBlock normalBlock))
        {
            if(normalBlock.color != color)
            {
                Minigame7.Instance.TryAgain();
            }
        }

        if(collision.gameObject.tag == "wallaralik")
        {
            Minigame7.Instance.TryAgain();
        }
    }
}
