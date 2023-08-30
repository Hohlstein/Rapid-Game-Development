using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptWriterMinigameTimer : MonoBehaviour
{
    public enum PlacementOptions
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    public PlacementOptions placement;
    public float Seconds;
    private TextMeshProUGUI DisplayText;
    public int ColorChangeThreshold;
    public bool freeze;
    public EndMiniGame minigame_ender;

    public scriptWriterMiniGameLogic logic;
    

    private RectTransform object_transform;
    private Color startColor;
    private Color thresholdColor;
    public int DisplaySeconds;
    private string minutes;
    private string seconds;
    private float StartClockTime;

    void Start(){
        DisplayText = GetComponent<TextMeshProUGUI>();
        StartClockTime = Time.time;
        startColor = DisplayText.color;
        thresholdColor = new Color32(255,0,0,255);
        object_transform = (RectTransform)gameObject.transform;
    }


    // Update is called once per frame
    void Update()
    {
        GoToPlacementPosition();
        //Die Anzeige kann eingefroren werden. Ist sie nicht eingefrorer, aktualisiert sie die übrigen Sekunden.
        if (freeze == false){
            //Die Sekunden, die übrig bleiben, werden über die Systemzeit berechnet. So ist die Anzeige FPS/Performance unabhängig.
            //DisplaySeconds enthält die übrigen Sekunden als solche, also z.B. bei 1:05 Minuten als 65.
            DisplaySeconds = (int)Mathf.RoundToInt(Seconds-(Time.time - StartClockTime));;
            if (DisplaySeconds < 0){
                //Ist der Timer abgelaufen, wird dies dem minigame_ender mitgeteilt.
                DisplaySeconds = 0;
                logic.calculatePoints();
                
            }
            //Die Sekunden und Minuten Anzahl werden berechnet.
            seconds = (DisplaySeconds % 60).ToString();
            if (DisplaySeconds % 60 < 10){
                //Ist die Sekundenzahl einstellig, wird eine führende 0 hinzugefügt.
                seconds = "0"+seconds;
            }
            minutes = (DisplaySeconds/60).ToString();
        }
        DisplayText.text = minutes + ":" + seconds;
        //Ist die übrige Zeit in Sekunden kleiner als der ColorChangeThreshold, wird die Farbe der Anzeige auf die thresholdColor gewechselt
        //(z.B. Rot, wenn nur noch 15 Sekunden übrig sind.)
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

    public string GetRemainingSeconds(){
        return seconds;
    }



    public void Freeze(){
        freeze = true;
    }

    public void Unfreeze(){
        freeze = false;
    }

    private void GoToPlacementPosition()
    {
        //Damit dieses Skript sehr einfach in mehreren MiniGames verwendet werden kann, kann die Ecke, in der der Timer angezeigt werden soll, einfach im Unity Editor
        //per Dropdown festgelegt werden.
        Vector3 newPosition = DisplayText.transform.localPosition;
        if (placement == PlacementOptions.BottomLeft || placement == PlacementOptions.BottomRight)
        {
            newPosition.y = (-1080)/2 + 70;
        }
        if (placement == PlacementOptions.TopLeft || placement == PlacementOptions.TopRight)
        {
            newPosition.y = (1080/2) - 70;
        }
        if (placement == PlacementOptions.BottomLeft || placement == PlacementOptions.TopLeft)
        {
            newPosition.x =(-1920/2) + 138;
        }
        if (placement == PlacementOptions.BottomRight || placement == PlacementOptions.TopRight)
        {
            newPosition.x = (1920/2) - 138;
        }
        DisplayText.transform.localPosition = newPosition;
    }
}
