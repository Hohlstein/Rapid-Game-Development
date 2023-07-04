/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentageBar : MonoBehaviour
{
    public float current_val;
    public float target_val;
    public float friction;
    public Image image;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(current_val/100, rectTransform.localScale.y, rectTransform.localScale.z);
        if (current_val != target_val){
            float change = (target_val-current_val)/friction;
            setCurrentVal(current_val + change);
        }
    }

    public void setCurrentVal(float x){
        current_val = x;
    }

    public void setTargetVal(float x){
        target_val = x;
    }
}
