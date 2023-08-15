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
    private List<DialogueNode> dialogueStart;

    [SerializeField]
    private Rarity rarity;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  
    }

    void Update()
    {

    }

    public string GetEventName()
    {
        return eventName;
    }

    public List<DialogueNode> getDialogueStart() {
        return dialogueStart;
    }
}