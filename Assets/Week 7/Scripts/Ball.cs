using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 spawnPos;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Reset();
        Controller.score++;
        //score++;
    }

    void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = spawnPos;
    }
}
