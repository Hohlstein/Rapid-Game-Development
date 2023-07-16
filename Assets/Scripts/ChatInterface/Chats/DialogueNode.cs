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
    private int eventOption;

    [SerializeField]
    private List<PlayerAnswer> playerAnswer;

    [SerializeField]
    private bool finalNode;

    void Start() {
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
}