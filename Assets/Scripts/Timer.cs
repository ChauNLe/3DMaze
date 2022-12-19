using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    private void OnEnable()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        timeRemaining = 90 + 10*FindObjectOfType<GameManager>().level;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 1)
            {
                if (FindObjectOfType<PlayerMove>().speed == 5f){
                    timeRemaining -= Time.deltaTime*2;
                }
                else {
                    timeRemaining -= Time.deltaTime;
                }
                DisplayTime(timeRemaining);
            }
            else
            {
                FindObjectOfType<GameManager>().GameOver();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}