/*
Author: Fabian Wiehn
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreeRoot : MonoBehaviour
{
    [SerializeField]
    private String eventName;

    [SerializeField]
    private DialogueNode dialogueStart;

    void Start()
    {

    }

    void Update()
    {

    }

    public string GetEventName()
    {
        return eventName;
    }

    public DialogueNode getDialogueStart() {
        return dialogueStart;
    }
}