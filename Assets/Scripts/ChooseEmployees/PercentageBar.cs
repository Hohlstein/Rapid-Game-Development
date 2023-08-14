/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageBar : MonoBehaviour
{
    public float Current_val;
    public float Target_val;
    public float friction;
    public Image image;
    
    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        //Die Image Komponente wird so skaliert, dass sie dem anzuzeigenden Wert in % entspricht.
        rectTransform.localScale = new Vector3(Current_val/100, rectTransform.localScale.y, rectTransform.localScale.z);
        if (Current_val != Target_val){
            //Ist der anzuzeigende Wert nicht gleich dem Zielwert (Target_val), wird die Differenz berechnet und durch Friction geteilt. Um diesen Wert ändert sich der angezeigte Wert.
            //D.h. bei niedriger Friction wird der Zielwert schnell erreicht, bei hoher dauert es länger.
            float change = (Target_val-Current_val)/friction;
            setCurrentVal(Current_val + change);
        }
    }

    public void setCurrentVal(float x){
        Current_val = x;
    }

    public void setTargetVal(float x){
        Target_val = x;
    }
}
