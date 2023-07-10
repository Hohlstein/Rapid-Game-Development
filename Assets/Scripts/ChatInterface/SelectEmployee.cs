/*
Author: Fabian Wiehn
*/
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class SelectEmployee : MonoBehaviour{
    public Image notSelected;
    public Sprite selected;

    public static SelectEmployee activeButton; // Track the active button

    public Sprite defaultSprite;

    void start() {

    }

    void Update() {

    }

    public void Selected() {
        if (activeButton != null)
        {
            activeButton.ResetButton();
        }
        activeButton = this;
        notSelected.sprite = selected;
    }

    public void ResetButton()
    {
        notSelected.sprite = defaultSprite;
    }
}