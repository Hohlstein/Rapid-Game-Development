/*
Author: Fabian Wiehn
*/
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Select_DisplayEmployeeChat : MonoBehaviour{
    public Image notSelected;
    public Sprite selected;

    public static Select_DisplayEmployeeChat activeButton; // Track the active button
    public TextMeshProUGUI selectedEmployeeName;
    public Sprite defaultSprite;

    void Start() {

    }

    void Update() {
        
    }

    public void DisplaySelectedName() {
        string buttonText = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(buttonText);
        selectedEmployeeName.text = buttonText;
    }

    public void Selected() {
        if (activeButton != null)
        {
            activeButton.ResetButton();
        }
        activeButton = this;
        notSelected.sprite = selected;
    }

    private void ResetButton()
    {
        notSelected.sprite = defaultSprite;
    }
}