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

    private int dialogueIndex;

    private bool miniGameDialogueTracker;

    private int existingProblemCharacterTracker; 

    private int problemDialogueIndex;

    


    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }
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
        string lastPlayedMiniGame = PlayerPrefs.GetString("LastMinigame");
        float miniGameBoost = PlayerPrefs.GetFloat("MiniGameBoost");
        Debug.Log("LastplayedMiniGame: "+ lastPlayedMiniGame);
        Debug.Log("miniGameBoost" + miniGameBoost);
        if(lastPlayedMiniGame == "coding"){
            if(miniGameBoost <= 1.33){
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[2];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("bad");
                    selectedDialogue = miniGameDialoguesCoding[dialogueIndex];
                }
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[5];
                }else{
                    dialogueIndex= generateSpecificMiniGameDialogueIndex("decent");
                    selectedDialogue = miniGameDialoguesCoding[dialogueIndex];
                }
            }  
            if(miniGameBoost > 1.66) {
                if(employee.getCodingSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesCoding[8];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("good");
                    selectedDialogue = miniGameDialoguesCoding[dialogueIndex];
                }
            }
        }

        if(lastPlayedMiniGame == "gamedesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[2];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("bad");
                    selectedDialogue = miniGameDialoguesStory[dialogueIndex];
                } 
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[5];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("decent");
                    selectedDialogue = miniGameDialoguesStory[dialogueIndex];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getGameDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesStory[8];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("good");
                    selectedDialogue = miniGameDialoguesStory[dialogueIndex];
                }
            }
        }

        if(lastPlayedMiniGame == "graphicdesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[2];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("bad");
                    selectedDialogue = miniGameDialoguesGraphic[dialogueIndex];
                }
                
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[5];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("decent");
                    selectedDialogue = miniGameDialoguesGraphic[dialogueIndex];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getGraphicDesignSkill() < skillThreshold){
                    selectedDialogue = miniGameDialoguesGraphic[8];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("good");
                    selectedDialogue = miniGameDialoguesGraphic[dialogueIndex];
                }
            }
        }

        if(lastPlayedMiniGame == "sounddesign"){
            if(miniGameBoost <= 1.33){
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[2];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("bad");
                    selectedDialogue = miniGameDialoguesSound[dialogueIndex];
                }
                
            }
            if(miniGameBoost > 1.33 && miniGameBoost <= 1.66) {
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[5];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("decent");
                    selectedDialogue = miniGameDialoguesSound[dialogueIndex];
                }
            }
            if(miniGameBoost > 1.66) {
                if(employee.getSoundDesignSkill() < skillThreshold) {
                    selectedDialogue = miniGameDialoguesSound[8];
                }else{
                    dialogueIndex = generateSpecificMiniGameDialogueIndex("good");
                    selectedDialogue = miniGameDialoguesSound[dialogueIndex];
                }
            }
        }
        miniGameDialogueTracker = true;
        return selectedDialogue;
    } 

    //Chooses between all the possible randomized dialogueOptions 
    public DialogueNode getRandomDialogueOption(Mitarbeiter employee){
        weekTracker = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        List<DialogueNode> dialogueStarts;
        DialogueTreeRoot selectedDialogue = null;
        DialogueNode selectedDialogueStart = null; 
        int randomNumber = UnityEngine.Random.Range(0,4);
        int startIndex = 0;
        Debug.Log("Woche: "+ weekTracker);
        if(employee.getProblemCharacter() == true && existingProblemCharacterTracker >=1) {
            selectedDialogue = chooseRandomProblemDialogue(employee);
        }else{
            if(randomNumber >=2 && weekTracker > 1 && miniGameDialogueTracker == false){
                selectedDialogue = chooseRandomMiniGameDialogue(employee);
                Debug.Log("IM in MINIGAME DIALOGUES");
            }else{
                selectedDialogue = chooseRandomRarityDialogue(getRandomRarity());
                Debug.Log("IM in RARITY DIALOGUES");
            }    
                
                dialogueStarts = selectedDialogue.getDialogueStart();
                if(problemDialogueIndex == 1){
                    selectedDialogueStart= dialogueStarts[problemDialogueIndex];
                    problemDialogueIndex = 0;
                }
                if(dialogueStarts.Count == 1) {
                    selectedDialogueStart = dialogueStarts[0];
                    removeDialogueOptions(dialogueIndex, startIndex, selectedDialogue.getRarity());
                }else{
                    startIndex = UnityEngine.Random.Range(0,dialogueStarts.Count);
                    Debug.Log("StartIndex: "+startIndex);
                    Debug.Log("DialogueStarts.Count() "+dialogueStarts.Count);
                    selectedDialogueStart = dialogueStarts[startIndex]; //HIER MAYBE COUNT -1 muss ich noch testen
                    removeDialogueOptions(dialogueIndex, startIndex, selectedDialogue.getRarity());
                }
        }
        return selectedDialogueStart;
    }

    //generates the index for the Specific MiniGameDialogues
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

    //removes dialogues from the corresponding list
    private void removeDialogueOptions(int dialogueIndexDelete, int startIndexDelete,Rarity rarity){
        if(rarity == Rarity.common){
            commonDialogues[dialogueIndexDelete].deleteStartOption(startIndexDelete);
            if(commonDialogues[dialogueIndexDelete].getDialogueStart().Count == 0){
                commonDialogues.RemoveAt(dialogueIndexDelete);
            }
        }
        if(rarity == Rarity.rare){
            rareDialogues[dialogueIndexDelete].deleteStartOption(startIndexDelete);
            if(rareDialogues[dialogueIndexDelete].getDialogueStart().Count == 0){
                rareDialogues.RemoveAt(dialogueIndexDelete);
            }
        }
        if(rarity == Rarity.veryRare){
            veryRareDialogues[dialogueIndexDelete].deleteStartOption(startIndexDelete);
            if(veryRareDialogues[dialogueIndexDelete].getDialogueStart().Count == 0){
                veryRareDialogues.RemoveAt(dialogueIndexDelete);
            }
        }
    }

    //Chooses Random Problem Dialogue
    private DialogueTreeRoot chooseRandomProblemDialogue(Mitarbeiter employee){
        DialogueTreeRoot selectedDialogue = null;
        if(existingProblemCharacterTracker == 1){
            int randomNumber =  UnityEngine.Random.Range(0,problemDialogues.Count);
            dialogueIndex = randomNumber;
            problemDialogueIndex = 1;
            existingProblemCharacterTracker++;
            selectedDialogue = problemDialogues[dialogueIndex];
        }
        if(existingProblemCharacterTracker == 2){
            selectedDialogue = problemDialogues[problemDialogueIndex+1];
            existingProblemCharacterTracker = 0;
        }
        return selectedDialogue;
    }

    //Rolls whether an employee will become a problem character
    //After first dialogue second dialoge must be from another employee
    private bool makeProblemCharacter(Mitarbeiter employee) {
        if(weekTracker > 1) {
            int randomNumber = UnityEngine.Random.Range(1, 31);
            if(existingProblemCharacterTracker == 0){
                if(randomNumber == 20) 
                    employee.setProblemCharacter(true);
                    return true;
                    existingProblemCharacterTracker = 1;
                }else {
                    return false;
                }
        }
        return false; 
    }      
}
