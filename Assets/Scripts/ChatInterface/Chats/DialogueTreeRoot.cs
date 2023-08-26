/*
Author: Fabian Wiehn
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTreeRoot : MonoBehaviour
{

    [SerializeField]
    private List<DialogueNode> dialogueStart;

    [SerializeField]
    private Rarity rarity;

    void Start()
    {
        this.gameObject.SetActive(false);  
    }

    void Update()
    {

    }

    public List<DialogueNode> getDialogueStart() {
        return dialogueStart;
    }

    public Rarity getRarity(){
        return rarity;
    }
}