using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public AnimationCurve smaller;

    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += 0.3f * Time.deltaTime;
        //evaluate the animation with timer
        float interpolation = smaller.Evaluate(timer);
        if (transform.localScale.z < 0.1f)
        {
            //check the gameobject's size and destroy it
            Destroy(gameObject);
        }
        //scaling transform with lerp
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
    }
}
