using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] float totalTime = 60.0f;
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        // Decrease the current time by one second every frame
        currentTime -= Time.deltaTime;

        // Check if the timer has expired
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
            Debug.Log("Time is up!");
        }

        // Display the current time as a formatted string
        string minutes = Mathf.FloorToInt(currentTime / 60.0f).ToString("00");
        string seconds = Mathf.FloorToInt(currentTime % 60.0f).ToString("00");
        timerText.text = string.Format("Time: {0}:{1}", minutes, seconds);
    }
}
