using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Plane"))
        {
            currentScore ++;
            Debug.Log("Current Score:" + currentScore);
        }
    }
}
