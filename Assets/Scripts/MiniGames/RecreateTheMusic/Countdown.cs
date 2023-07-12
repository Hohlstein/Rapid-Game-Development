/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Countdown : MonoBehaviour
{
    public float Seconds;
    public TextMeshProUGUI DisplayText;
    public int ColorChangeThreshold;
    public bool freeze;

    private Color startColor;
    private Color thresholdColor;
    private int DisplaySeconds;
    private string minutes;
    private string seconds;
    private float StartClockTime;

    void Start(){
        StartClockTime = Time.time;
        startColor = DisplayText.color;
        thresholdColor = new Color32(255,0,0,255);
    }


    // Update is called once per frame
    void Update()
    {
        if (freeze == false){
            DisplaySeconds = (int)Mathf.RoundToInt(Seconds-(Time.time - StartClockTime));;
            if (DisplaySeconds < 0){
                DisplaySeconds = 0;
                Debug.Log("TIMEOUT!!!");
            }
            seconds = (DisplaySeconds % 60).ToString();
            if (DisplaySeconds % 60 < 10){
                seconds = "0"+seconds;
            }
            minutes = (DisplaySeconds/60).ToString();
        }
        DisplayText.text = minutes + ":" + seconds;
        if (DisplaySeconds <= ColorChangeThreshold){
            DisplayText.color = thresholdColor;
        }
        else{
            DisplayText.color = startColor;
        }
    }
}
