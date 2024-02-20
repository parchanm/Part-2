using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.3f;
    Vector2 lastPosition;
    Vector2 destination;
    Vector2 movement;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 20;
    public float attackTimer = 1;
    public int score = 0;

    bool moveSwitch = false;
    bool isDead;
    bool attacking = false;

    private void OnMouseDown()
    {
        if (isDead) return;
        points = new List<Vector2>();
        //Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        moveSwitch = false;
    }

    private void OnMouseDrag()
    {
        if (isDead) return;
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
        

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        attacking = (points.Count > 0 && moveSwitch);
        //animator.SetFloat("Movement", movement.magnitude);
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        if (!moveSwitch) return;

        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rigidbody.MovePosition(rigidbody.position + movement.normalized * speed * Time.deltaTime);

        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (!attacking && attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            return;
        }

        if (points.Count > 0)
        {
            rigidbody.MovePosition(rigidbody.position + (points[0] - currentPosition).normalized * speed * Time.deltaTime);
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseUp()
    {
        attackTimer = 1;
        moveSwitch = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && attacking == true)
        {
            Destroy(collision.gameObject);
            score ++;
        } else
        {
            Destroy(gameObject);
        }
    }
}
