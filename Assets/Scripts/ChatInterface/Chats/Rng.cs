using System;
using UnityEngine;
using System.Collections.Generic;
public class Rng : MonoBehaviour{
        [SerializeField]
    private List<DialogueTreeRoot> commonDialogues;
        [SerializeField]
    private List<DialogueTreeRoot> rareDialogues;
        [SerializeField]
    private List<DialogueTreeRoot> veryRareDialogues;
        [SerializeField]
    private List<DialogueTreeRoot> problemDialogues;
        [SerializeField]
    private List<DialogueTreeRoot> miniGameDialoguesSound;
        [SerializeField]
    private List<DialogueTreeRoot> miniGameDialoguesGraphic;
        [SerializeField]
    private List<DialogueTreeRoot> miniGameDialoguesStory; 
        [SerializeField]
    private List<DialogueTreeRoot> miniGameDialoguesCoding;

    private int skillThreshold = 60;
    
    private int weekTracker;

    //gets a randomly generated rarity and passes it to chooseRandomDialoge
    private Rarity getRandomRarity(){
        RarityInfo commonRarity = new RarityInfo(Rarity.common);
        RarityInfo rareRarity = new RarityInfo(Rarity.rare);
        RarityInfo veryRareRarity = new RarityInfo(Rarity.veryRare);

        double roundedValue = Math.Round(UnityEngine.Random.value, 2);
        
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
    private DialogueTreeRoot chooseRandomRarityDialogue(Rarity rarity) {
        DialogueTreeRoot selectedDialogue = null;
        if(rarity == Rarity.common){
            int random = UnityEngine.Random.Range(0,commonDialogues.Count-1);
            selectedDialogue = commonDialogues[random];
        }
        if(rarity == Rarity.rare){
            int random = UnityEngine.Random.Range(0,rareDialogues.Count-1);
            selectedDialogue = rareDialogues[random];
        }
        if(rarity == Rarity.veryRare){
            int random = UnityEngine.Random.Range(0,veryRareDialogues.Count-1);
            selectedDialogue = veryRareDialogues[random];
        }
        return selectedDialogue;
    }
    //Chooses the right category and the appropriate dialogue option
    private DialogueTreeRoot chooseRandomMiniGameDialogue(Mitarbeiter employee) {
        DialogueTreeRoot selectedDialogue = null;
        string lastPlayedMiniGame = PlayerPrefs.GetString("LastMiniGame");
        float miniGameBoost = PlayerPrefs.GetFloat("MiniGameBoost");
        Debug.Log("LastplayedMiniGame: "+ lastPlayedMiniGame);
        Debug.Log("miniGameBoost" + miniGameBoost);
        if(lastPlayedMiniGame == "coding"){
            if(miniGameBoost <= 1.33){
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[2];
                }else{
                    selectedDialogue = miniGameDialoguesCoding[generateSpecificMiniGameDialogueIndex("bad")];
                }
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[5];
                }else{
                    selectedDialogue = miniGameDialoguesCoding[generateSpecificMiniGameDialogueIndex("decent")];
                }
            }  
            if(miniGameBoost > 1.66) {
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[8];
                }else{
                    selectedDialogue = miniGameDialoguesCoding[generateSpecificMiniGameDialogueIndex("good")];
                }
            }
        }

        if(lastPlayedMiniGame == "gamedesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[2];
                }else{
                    selectedDialogue = miniGameDialoguesStory[generateSpecificMiniGameDialogueIndex("bad")];
                } 
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[5];
                }else{
                    selectedDialogue = miniGameDialoguesStory[generateSpecificMiniGameDialogueIndex("decent")];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[8];
                }else{
                    selectedDialogue = miniGameDialoguesStory[generateSpecificMiniGameDialogueIndex("good")];
                }
            }
        }

        if(lastPlayedMiniGame == "graphicdesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[2];
                }else{
                    selectedDialogue = miniGameDialoguesGraphic[generateSpecificMiniGameDialogueIndex("bad")];
                }
                
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[5];
                }else{
                    selectedDialogue = miniGameDialoguesGraphic[generateSpecificMiniGameDialogueIndex("decent")];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[8];
                }else{
                    selectedDialogue = miniGameDialoguesGraphic[generateSpecificMiniGameDialogueIndex("good")];
                }
            }
        }

        if(lastPlayedMiniGame == "sounddesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[2];
                }else{
                    selectedDialogue = miniGameDialoguesSound[generateSpecificMiniGameDialogueIndex("bad")];
                }
                
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[5];
                }else{
                    selectedDialogue = miniGameDialoguesSound[generateSpecificMiniGameDialogueIndex("bad")];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[8];
                }else{
                    selectedDialogue = miniGameDialoguesSound[generateSpecificMiniGameDialogueIndex("bad")];
                }
            }
        }
        return selectedDialogue;
    } 

    //Vielleicht sollte ich auch bei denen mit mehr wie einer startoption die startoption randomizen und nach verwendung rauslöschen 
    public DialogueNode getRandomDialogueOption(Mitarbeiter employee){
        weekTracker = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        List<DialogueNode> dialogueStarts;
        DialogueTreeRoot selectedDialogue = null;
        DialogueNode selectedDialogueStart = null; 
        int randomNumber = UnityEngine.Random.Range(0,4);
        Debug.Log("Woche: "+ weekTracker);
        if(randomNumber >=2 && weekTracker > 1){
            selectedDialogue = chooseRandomMiniGameDialogue(employee);
             Debug.Log("IM in MINIGAME DIALOGUES");
        }else{
            selectedDialogue = chooseRandomRarityDialogue(getRandomRarity());
            Debug.Log("IM in RARITY DIALOGUES");
        }    
            Debug.Log("SelectedDialogue" + selectedDialogue);
            dialogueStarts = selectedDialogue.getDialogueStart();
            if(dialogueStarts.Count == 1) {
            selectedDialogueStart = dialogueStarts[0];
            }
            selectedDialogueStart = dialogueStarts[UnityEngine.Random.Range(0,dialogueStarts.Count)]; //HIER MAYBE COUNT -1 muss ich noch testen
        
        
        return selectedDialogueStart;
    }

    private int generateSpecificMiniGameDialogueIndex(string score){
        int randomNumber = 0;
        if(score == "bad"){
            randomNumber = UnityEngine.Random.Range(0, 2);
        }
        if(score == "decent") {
            randomNumber = UnityEngine.Random.Range(3,5);
        }
        if(score == "good") {
            randomNumber = UnityEngine.Random.Range(6,8);
        }
        return randomNumber;
    }

}   