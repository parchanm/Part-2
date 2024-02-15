using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restwo()
    {
        Debug.Log("Changing Res to 1280, 720");
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }
}
