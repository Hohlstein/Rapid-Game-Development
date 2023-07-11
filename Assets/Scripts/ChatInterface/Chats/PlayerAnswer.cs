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

    void Start() {
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
}