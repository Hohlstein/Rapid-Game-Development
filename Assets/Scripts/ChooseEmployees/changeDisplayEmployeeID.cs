/*
Author: Klaus Wiegmann
*/
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class changeDisplayEmployeeID : MonoBehaviour
{
    
    /*
    Dieses Skript aktualisiert die angezeigte Profilinformation auf dem Bildschirm.
    Dazu gehören der Name, Alter, etc. der Person, die ID oben rechts (nur für Debug Zwecke) und die 4 Farbstreifen.
     Es ist auch dafür zuständig, die aktuell angezeigte ID zu aktualisieren (als Reaktion auf die Pfeil Buttons)
    */
    public TextMeshProUGUI IDText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI AgeText;
    public TextMeshProUGUI RelationshipstatusText;
    public TextMeshProUGUI BioText;
    public EmployeeInfo infosource;
    public Checkbox checkbox;
    public SmoothMove textParent;
    public Image avatar;

    public PercentageBar CodingSkill;
    public PercentageBar GameDesignSkill;
    public PercentageBar GraphicDesignSkill;
    public PercentageBar SoundDesignSkill;

    private int numberOfPeople;
    public float textAnimationY;


    private int ID = 0;

    public void Start(){
        /*
        Anfangs werden Dummy Werte eingetragen, die aber dann sofort überschrieben werdn
        */
        IDText.text = "0";
        NameText.text = "NAME HERE";
        AgeText.text = "AGE HERE";
        RelationshipstatusText.text = "RELATIONSHIP HERE";
        BioText.text = "BIO HERE";
        ID = 0;
    }

    public void Update(){
        /*
        Angezeigte Werte werden am laufenden Band aktuell gehalten, reagieren also direkt darauf, wenn die anzuzeigende ID gewechselt wird.
        */
        UpdateDisplayedValues();
    }

    public void ChangeID(int direction){
        /*
        Hier wird als Reaktion auf die Pfeil Buttons die ID gewechselt. Direction ist entweder -1 (linker Pfeil) oder 1 (rechter Pfeil.)
        Damit die ID keine ungültigen Werte annimmt, wird mit Modulo gerechnet.
        */
        numberOfPeople = infosource.getNumberOfPeople();
        ID = (ID + direction) % numberOfPeople;
        if (ID < 0) {
            ID = numberOfPeople-1;
        }
        animateUIElements();
        UpdateDisplayedValues();
        
    }

    public void SetID(int input_ID){
        /*
        Hier wird die ID manuell eingestellt. Dies ist z.B. der Fall, wenn man eine Person bereits zur Liste hinzugefügt hat und auf das Listenelement klickt, um zum Profil der Person zu gelangen.
        */
        numberOfPeople = infosource.getNumberOfPeople();
        
        if (ID >= 0 && ID < numberOfPeople) {
            ID = input_ID;
        }
        animateUIElements();
        UpdateDisplayedValues();
        
    }


    private void animateUIElements(){
        CodingSkill.setCurrentVal(0);
        GameDesignSkill.setCurrentVal(0);
        GraphicDesignSkill.setCurrentVal(0);
        SoundDesignSkill.setCurrentVal(0);
        textParent.setCurrentY(textAnimationY);
    }

    private void UpdateDisplayedValues()
    {
        /*
        Die aktualisierten Werte werden bei infosource (INFO_HireList) abgefragt und an die jeweiligen UI Elemente weitergegeben.
        */
        IDText.text = ID.ToString();
        NameText.text = infosource.getValueString(ID,"firstName") + " " + infosource.getValueString(ID,"lastName");
        AgeText.text = infosource.getValueString(ID,"Age") + " years old";
        RelationshipstatusText.text = infosource.getValueString(ID,"relationshipStatus");
        BioText.text = infosource.getValueString(ID,"Bio");
        avatar.sprite = infosource.GetAvatar(ID);

        CodingSkill.setTargetVal(infosource.getValueFloat(ID,"codingskill"));
        GraphicDesignSkill.setTargetVal(infosource.getValueFloat(ID,"graphicdesignskill"));
        GameDesignSkill.setTargetVal(infosource.getValueFloat(ID,"gamedesignskill"));
        SoundDesignSkill.setTargetVal(infosource.getValueFloat(ID,"sounddesignskill"));
        checkbox.UpdateSprite();
    }

    public int getCurrentID(){
        return ID;
    }

}