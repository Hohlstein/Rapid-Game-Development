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
    private DialogueTreeRoot chooseRandomHoursDialogue(Rarity rarity) {
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
        //lastPlayedMiniGame = PlayerPrefs.GetString("Codingforweekly")/("GameDesignforweekly")/("GraphicDesignforweekly")/("SoundDesignforweekly");
        return null;
    } 

    //Vielleicht sollte ich auch bei denen mit mehr wie einer startoption die startoption randomizen und nach verwendung rauslöschen 
    public DialogueNode getRandomDialogueOption(Mitarbeiter employee){
        weekTracker = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        List<DialogueNode> dialogueStarts;
        DialogueNode selectedDialogueStart = null; 
        //if hours event
        //if bedingung muss noch gesetzt werden
        
            DialogueTreeRoot selectedDialogue = chooseRandomHoursDialogue(getRandomRarity());
            dialogueStarts = selectedDialogue.getDialogueStart();
            if(dialogueStarts.Count == 1) {
            selectedDialogueStart = dialogueStarts[0];
            }
            selectedDialogueStart = dialogueStarts[UnityEngine.Random.Range(0,dialogueStarts.Count-1)];
        
        //Vermerken der Bereiche durch die entsprechende Liste in den Dialogen da diesma keine raritys brauch ich nur die liste
        //
        //if(Bedingung) muss noch gesetzt werden
        //if() {//!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
            //getRandomMiniGameDialogue
        //}
        return selectedDialogueStart;
    }

}   