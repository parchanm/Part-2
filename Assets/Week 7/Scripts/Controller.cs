using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float charge;
    public float maxCharge = 1;
    Vector2 direction;
    public TextMeshProUGUI showScore;

    public static Player SelectedPlayer { get; private set; }
    public static float score = 0;

    public static void SetSelectedPlayer(Player player)
    {
        if(SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        player.Selected(true);
        SelectedPlayer = player;
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            //reset everything for the next time
            direction = Vector2.zero;
            charge = 0;
            chargeSlider.value = charge;
        }
    }
    private void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetKeyDown(KeyCode.Space)) {
            charge = 0;
            Mathf.Clamp(charge, 0, maxCharge);
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            charge += Time.deltaTime;
            chargeSlider.value = charge;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //see where the normalize is! just get the directions
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * charge;
        }
        UpdateScore();
    }

    public void UpdateScore()
    {
        showScore.text = "Score: " + score.ToString();
        //Debug.Log(showScore.text);
    }
}
