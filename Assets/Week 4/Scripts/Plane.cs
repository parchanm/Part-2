using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed;
    public AnimationCurve landing;
    float landingTimer;
    SpriteRenderer spriteRenderer;

    public Collider2D runwayCollider;

    public bool planeLanded = false;
    public int currentScore;

    //float planeDistance;
    //ublic float destroyDistance;

    //public GameObject[] planeSprite;
    public float planeRotation;

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }
        //do some clever stuff!
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        //set position quaternoion.identity for position here and speed 
        // quaternion euler
        //int speedRand = Random.Range(1, 6);
        //int rand = Random.Range(0, planeSprite.Length);
        //GameObject instance = (GameObject)Instantiate(planeSprite[rand], transform);

        speed = Random.Range(1, 3);

        Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.position = spawnPosition;

        float spawnRotation = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, spawnRotation);
    }

    private void FixedUpdate()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
            //

            //float planeDistance = Vector3.Distance(currentPosition
            //float destroyDistance = 1;

            //if (planeDistance < destroyDistance)
            //{
            //    Destroy(gameObject);
            //}
            //
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);

    }
    private void Update()
    {
        //if(Input.GetKey(KeyCode.Space))
        if (planeLanded ==true)
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i <lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i +1));
                }
                lineRenderer.positionCount--;
            }
        }
        //canavs size calculated
        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -5 || transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Plane"))
        {
            spriteRenderer.color = Color.red;

            float destroyRange = 1.46f;
            float distance = Vector3.Distance(transform.position, collision.transform.position);

            Debug.Log("Distance check:" + distance); //this debug.log was a savior

            if (distance < destroyRange)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Debug.Log("Boom");
            }
        }

        if (collision.CompareTag("Runway"))
        {
            planeLanded = true;
            Debug.Log("plane landed?:" + planeLanded);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
