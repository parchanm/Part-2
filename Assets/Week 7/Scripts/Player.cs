using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;
    public Color selectedColor;
    public Color unselectedColor;

    //bool selected = false;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    private void OnMouseDown()
    {
        Selected(true);
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
}
