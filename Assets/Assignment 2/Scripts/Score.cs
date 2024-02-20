using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Slider score; //score slider

    public void SetScore(float addScore)
    {
        score.value += addScore; //add sendmessage addscore value to slider
    }
}
