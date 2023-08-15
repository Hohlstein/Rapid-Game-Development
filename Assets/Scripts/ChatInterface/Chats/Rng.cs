using System;
using UnityEngine;
using System.Collections.Generic;
public class Rng : MonoBehaviour{
        [SerializeField]
    List<DialogueTreeRoot> commonDialogues;
        [SerializeField]
    List<DialogueTreeRoot> rareDialogues;
        [SerializeField]
    List<DialogueTreeRoot> veryRareDialogues;

    //gets a randomly generated rarity and passes it to chooseRandomDialoge
    private Rarity getRandomRarity(){
        RarityInfo commonRarity = new RarityInfo(Rarity.common);
        RarityInfo rareRarity = new RarityInfo(Rarity.rare);
        RarityInfo veryRareRarity = new RarityInfo(Rarity.veryRare);

        double roundedValue = Math.Round(UnityEngine.Random.value, 2);
        Debug.Log("RoundedValue " +roundedValue);
        
        Rarity selectedRarity = Rarity.common;
        if (roundedValue >= commonRarity.getMinValue() && roundedValue <= commonRarity.getMaxValue()) {
            selectedRarity = Rarity.common;
        }
        else if (roundedValue >= rareRarity.getMinValue() && roundedValue <= rareRarity.getMaxValue()) {
            selectedRarity = Rarity.rare;
        }
        else if (roundedValue >= veryRareRarity.getMinValue() && roundedValue <= veryRareRarity.getMaxValue()) {
            selectedRarity = Rarity.veryRare;
        }
        return selectedRarity;
    }

    //chooses a random Dialogue with the before chosen Rarity ((( Maybe -1 nach count notwendig!!!!!!!!!!!!!!!!!!!!!!!!!!)))
    private DialogueTreeRoot chooseRandomDialogue(Rarity rarity) {
        DialogueTreeRoot selectedDialogue = null;
        if(rarity == Rarity.common){
            int random = UnityEngine.Random.Range(0,commonDialogues.Count-1);
            Debug.Log("Random"+random);
            selectedDialogue = commonDialogues[random];
        }
        if(rarity == Rarity.rare){
            int random = UnityEngine.Random.Range(0,rareDialogues.Count-1);
            Debug.Log("Random"+random);
            selectedDialogue = rareDialogues[random];
        }
        if(rarity == Rarity.veryRare){
            int random = UnityEngine.Random.Range(0,veryRareDialogues.Count-1);
            Debug.Log("Random"+random);
            selectedDialogue = veryRareDialogues[random];
        }
        Debug.Log("selectedDialogue" + selectedDialogue);
        return selectedDialogue;
    }

    //Vielleicht sollte ich auch bei denen mit mehr wie einer startoption die startoption randomizen und nach verwendung rauslöschen 
    public DialogueNode getRandomDialogueOption(){
        DialogueTreeRoot selectedDialogue = chooseRandomDialogue(getRandomRarity());
        List<DialogueNode> dialogueStarts = selectedDialogue.getDialogueStart();
        Debug.Log("AnzahlDialogStart: "+ dialogueStarts.Count);
        if(dialogueStarts.Count == 1) {
            return dialogueStarts[0];
        }
        return dialogueStarts[UnityEngine.Random.Range(0,dialogueStarts.Count-1)]; //hier auch maybe -1 notwendig
    }
}   