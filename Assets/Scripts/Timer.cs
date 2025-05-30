using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    float currentTime = 0;

    private void Start()
    {
        timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        int sec;
        int min = (int)currentTime / 60;
        if(min >= 1)
        {
            sec = (int)currentTime % 60;
        }
        else
        {
            sec = (int)currentTime;
        }
        timeText.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    public string GetTime()
    {
        int sec;
        int min = (int)currentTime / 60;
        if (min >= 1)
        {
            sec = (int)currentTime % 60;
        }
        else
        {
            sec = (int)currentTime;
        }
        return min.ToString("00") + ":" + sec.ToString("00");
    }
}
