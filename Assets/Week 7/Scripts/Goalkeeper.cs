using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public GameObject goal;
    public float maxRadius = 2;
    public float speed = 10;

    Rigidbody2D rb;
    Vector2 goalCenter;

    Player thisPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goalCenter = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        thisPlayer = Controller.SelectedPlayer;
    }

    private void FixedUpdate()
    {
        Vector2 setRadius = rb.position - goalCenter;

        //noteforlater vector2 name.magnitude for distance
        float distanceCheck = setRadius.magnitude;
        Debug.Log("distance: " + distanceCheck);

        if (thisPlayer != null)
        {
            //noteforlater goalie ,(to ->) player, speed * time.delta

            /*Vector2 followPlayer = Vector2.MoveTowards(transform.position, thisPlayer.transform.position, speed * Time.deltaTime);
            transform.position = followPlayer;*/

            //noteforlater (this object's) transform.position - (selected player's) thisPlayer.transform.position calculates direction
            Vector2 direction = thisPlayer.transform.position - transform.position;

            if (direction.magnitude > maxRadius)
            {
                Vector2 thisPosition = Vector2.MoveTowards(transform.position, thisPlayer.transform.position, speed * Time.deltaTime);
                rb.MovePosition(thisPosition);
            }
            else
            {
                Vector2 position = goalCenter + setRadius.normalized * maxRadius;
                rb.MovePosition(position);
            }
        }
        /*if (distanceCheck > maxRadius)
        {
            Vector2 position = goalCenter + setRadius.normalized * maxRadius;
            rb.MovePosition(position);
        }*/
    }
}
