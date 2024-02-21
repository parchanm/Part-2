using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    public Color selectedColor;
    public Color unselectedColor;
    public float speed = 10;

    //bool selected = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Selected(bool isSelected)
    {
        if(isSelected)
        {
            sr.color = selectedColor;
        } else
        {
            sr.color = unselectedColor;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
}
