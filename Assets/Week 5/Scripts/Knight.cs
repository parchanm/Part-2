using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        isDead = false;
    }

    private void FixedUpdate()
    {
        if (isDead) return; //stop doing the function give up this frame
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    void Update()
    {
        if (isDead) return;
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        TakeDamage(1);
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;

    }

    void TakeDamage(float damage)
    {
        health -= damage;
        Mathf.Clamp(health, 0, maxHealth);
        if(health <= 0)
        {
            //die!
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }
    }
}
