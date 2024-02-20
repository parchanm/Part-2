using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 spawnPosition = new Vector3(Random.Range(-7, 7), Random.Range(-7, 7), 0);
        transform.position = spawnPosition;

        speed = Random.Range(1, 3);
        float startRotation = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, startRotation);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x < -12 || transform.position.x > 12 || transform.position.y < -7 || transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
}
