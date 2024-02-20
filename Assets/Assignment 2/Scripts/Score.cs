using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Slider score;

    public void TakeDamage(float scoreAdd)
    {
        //PlayerPrefs.SetFloat("Health", health);
        score.value += scoreAdd;

    }

    public void SetScore()
    {
        score.value = PlayerPrefs.GetFloat("Score");
    }
}
