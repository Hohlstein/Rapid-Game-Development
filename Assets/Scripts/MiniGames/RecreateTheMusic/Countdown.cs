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
    public enum PlacementOptions
    {
        BottomLeft,
        TopLeft,
        TopRight,
        BottomRight
    }

    public PlacementOptions placement;
    public float Seconds;
    public TextMeshProUGUI DisplayText;
    public int ColorChangeThreshold;
    public bool freeze;
    public EndMiniGame minigame_ender;
    


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
        GoToPlacementPosition();

        if (freeze == false){
            DisplaySeconds = (int)Mathf.RoundToInt(Seconds-(Time.time - StartClockTime));;
            if (DisplaySeconds < 0){
                DisplaySeconds = 0;
                minigame_ender.TimeOut();
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

    public void SetRemainingSeconds(float s){
        Seconds = s;
    }

    public void Freeze(){
        freeze = true;
    }

    public void Unfreeze(){
        freeze = false;
    }

    private void GoToPlacementPosition()
    {
        Vector3 newPosition = transform.position;
        if (placement == PlacementOptions.BottomLeft || placement == PlacementOptions.BottomRight)
        {
            newPosition.y = 70;
        }
        if (placement == PlacementOptions.TopLeft || placement == PlacementOptions.TopRight)
        {
            newPosition.y = 1080 - 70;
        }
        if (placement == PlacementOptions.BottomLeft || placement == PlacementOptions.TopLeft)
        {
            newPosition.x = 138;
        }
        if (placement == PlacementOptions.BottomRight || placement == PlacementOptions.TopRight)
        {
            newPosition.x = 1920 - 138;
        }
        transform.position = newPosition;
    }
}
