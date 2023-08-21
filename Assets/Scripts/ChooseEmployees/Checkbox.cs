/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkbox : MonoBehaviour
{
    /*
    Die Checkbox benötigt:
        - ID_info (Canvas), um die aktuelle ID erhalten zu können
        - HiredEmployees (INFO_HireList), um abzufragen, welche IDs zurzeit als angestellt eingetragen sind
        - Image, um das Bild der Checkbox auswechsel zu können
        - Sprites onSprite und offSprite, um je nach eingestellten Zustand zwischen den beiden PNGs wechseln zu können.

        bool toggle enthält den aktuellen Zustand (true -> an, false -> aus)
    */
    public changeDisplayEmployeeID ID_info;
    public HiredEmployees HiredEmployees;
    public Image image;
    public Sprite onSprite;
    public Sprite offSprite;
    public Button button;

    private int ID;
    private bool toggle;

    public void press(){
        //Ist der Schalter zurzeit an, wird er auf aus gestellt. Sonst andersrum.
        
        UIAudioPlayer UISounds = GetComponent<UIAudioPlayer>();
        if (toggle){
            UISounds.TriggerSound(1);
            toggle = false;
        }
        else{
            UISounds.TriggerSound(0);
            toggle = true;
        }
        
        //Der neue Wert wird an HiredEmployees übermittelt und dort in die Liste eingetragen.
        HiredEmployees.set(ID,toggle);
    }

    // Update is called once per frame
    public void UpdateSprite()
    {
        /*
        Am laufenden Band wird überprüft, welche ID zurzeit angezeigt wird.
        Toggle wird auf den aktuell für diese ID eingetragenen Wert aktualisiert.
        Das angezeigte Bild wird dementsprechend angepasst.
        */
        ID = ID_info.getCurrentID();
        toggle = HiredEmployees.isHired(ID);
        int numberOfEmployeesSoFar = HiredEmployees.getNumberOfSelectedEmployees();
        if (toggle){
            image.sprite = onSprite;
        }
        else{
            image.sprite = offSprite;
            
        }

        //Damit keine weiteren Mitarbeiter mehr zur Auswahl hinzugefügt werden können, wenn bereits 4 ausgewählt sind, wird der Button 
        //deaktiviert. Dies geschieht jedoch nur, wenn der aktuelle Mitarbeiter noch nicht ausgewählt ist, da es dann immernoch möglich sein soll,
        //den aktuellen Mitarbeiter mit dem Button aus der Liste zu entfernen.
        if (numberOfEmployeesSoFar >= 4 && toggle == false){
            button.interactable = false;
        }
        else{
            button.interactable = true;
        }
        
    }

}
