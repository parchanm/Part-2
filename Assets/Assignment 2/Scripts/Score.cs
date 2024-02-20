using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Slider score;

    public void SetScore(float addScore)
    {
        score.value += addScore;
    }
}
