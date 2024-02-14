using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void TakeDamage(float damage)
    {
        //PlayerPrefs.SetFloat("Health", health);
        slider.value -= damage;

    }

    public void SetHealth()
    {
        slider.value = PlayerPrefs.GetFloat("Health");
    }
}
