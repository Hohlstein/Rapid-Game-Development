/*
Author: Fabian Wiehn
*/
using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : MonoBehaviour{
        [SerializeField]
    private string text;
        [SerializeField]
    private DialogueNode nextNode;
        [SerializeField]
    private bool finalNode;
        [SerializeField]
    private bool workingHoursUp; //True means + hours, false means - hours
        [SerializeField]
    private int amountOfHoursChanging;

    void Start() {
        this.gameObject.SetActive(false);
        if(finalNode == true) {
            nextNode = null;
        }
        if(nextNode == null) {
            End();
        }
    }

    void End() {

    }
    
    public string getText() {
        return text;
    }

    public DialogueNode getNextNode() {
        return nextNode;
    }

    public bool getFinalNode() {
        return finalNode;
    }

    public bool getWorkingHoursUp() {
        return workingHoursUp;
    }

    public int getAmountOfHoursChanging() {
        return amountOfHoursChanging;
    }
}