/*
Author: Fabian Wiehn
*/
using System;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode : MonoBehaviour {
        [SerializeField]
    private string text;
        [SerializeField]
    private List<PlayerAnswer> playerAnswer;
        [SerializeField]
    private bool finalNode;
        [SerializeField]
    private bool workingHoursUp; //True means + hours, false means -hours
        [SerializeField]
    private int amountOfHoursChanging;
        [SerializeField]
    private bool stressLevelUp; //True means + Stress, false means - stress
        [SerializeField]
    private int amountOfStressChanging;

    void Start() {
        this.gameObject.SetActive(false);
    }

    void Update() {

    }

    public string getText() {
        return text;
    }

    public bool getFinalNode() {
        return finalNode;
    }

    public List<PlayerAnswer> getPlayerAnswer() {
        return playerAnswer;
    }

    public int getAmountOfHoursChanging() {
        return amountOfHoursChanging;
    }

    public bool getWorkingHoursUp() {
        return workingHoursUp;
    }

    public bool getStressLevelUp(){
        return stressLevelUp;
    }

    public int getAmountOfStressChanging() {
        return amountOfStressChanging;
    }
}