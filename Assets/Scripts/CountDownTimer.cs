using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text textDisplay;
    public float secondsLeft;
    public CanvasGroup gameOver;
    public bool timerIsRunning = false;
    public HealthBarController healthBarCtrl;

    private void Start()
    {
        timerIsRunning = true;
        textDisplay.color = Color.red;
    }


    private void Update()
    {
        if (timerIsRunning)
        {
            if (secondsLeft > 0 && timerIsRunning)
            {
                secondsLeft -= 1 * Time.deltaTime;
                float seconds = secondsLeft % 60;
                double minutes = Math.Floor(secondsLeft / 60);

                textDisplay.text = minutes.ToString("00") + ":" +
                                   seconds.ToString("00");
            }
            else
            {
                gameOver.interactable = true;
                gameOver.blocksRaycasts = true;
                gameOver.alpha = 1f;

                healthBarCtrl.health = 100f;

                Time.timeScale = 0f;
                secondsLeft = 0;
                timerIsRunning = false;
            }
        }
    }
}