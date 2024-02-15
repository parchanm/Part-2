using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resone()
    {
        Debug.Log("Changing Res to 1920, 1080");
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }
}
