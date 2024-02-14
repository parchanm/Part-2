using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public HealthBar healthBar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //health = PlayerPrefs.GetFloat("Health", health);
        //isDead = false;

        gameObject.SendMessage("SetHealth");
        PlayerPrefs.GetFloat("Health");


        //push not working test 3
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
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1) && !clickingOnSelf)
        {
            animator.SetTrigger("Attack");
        }
        SetHealth();
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf = true;
        gameObject.SendMessage("TakeDamage", 1 , SendMessageOptions.DontRequireReceiver);
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        PlayerPrefs.SetFloat("Health", health);
        Mathf.Clamp(health, 0, maxHealth);

        

        if (PlayerPrefs.GetFloat("Health") <= 0)
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

    /*public void DealDamage(float swordDamage)
    {
    }*/

    public void SetHealth()
    {
        if (PlayerPrefs.GetFloat("Health") < 0 || PlayerPrefs.GetFloat("Health") > maxHealth)
        {
            health = maxHealth;
            PlayerPrefs.SetFloat("Health", health);
        }

        
        health = PlayerPrefs.GetFloat("Health", maxHealth);


        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }
}
