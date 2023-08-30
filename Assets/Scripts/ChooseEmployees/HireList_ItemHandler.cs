/*
Author: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HireList_ItemHandler : MonoBehaviour
{
    public HiredEmployees HiredEmployees_object;  
    public changeDisplayEmployeeID ID_changer;
    public ListItem_X x_button;
    public Image avatar;
    public PercentageBar coding_skill;
    public PercentageBar gamedesign_skill;
    public PercentageBar graphicdesign_skill;
    public PercentageBar sounddesign_skill;
    public float startX;
    public float startY;
    public float topOfListY;
    public float YDistanceBetweenItems;
    private int ID;
    private bool deleteOrderSent = false;
    
    public BalancingData BalancingData;
    
    public SmoothMove smoothMover;
    public TextMeshProUGUI ListItem_Text;
    

    // Start is called before the first frame update
    void Start()
    {
        smoothMover.setCurrentX(startX);
        smoothMover.setCurrentY(startY);
    }

    // Update is called once per frame
    void Update()
    {
        //Bei jedem Frame muss überprüft werden, ob dieser Mitarbeiter noch ausgewählt ist.
        checkIfListItemExists();
        smoothMover.setTargetX(startX);
        smoothMover.setTargetY(topOfListY + YDistanceBetweenItems*getItemIndex());
    }

    public void ThisItemClicked(){
        ID_changer.SetID(ID);
    }

    public void SetSkillLevels(float[] array){
        float SkillScaleFactor = BalancingData.SkillScaleFactor;
        coding_skill.setTargetVal(array[0]*SkillScaleFactor);
        gamedesign_skill.setTargetVal(array[1]*SkillScaleFactor);
        graphicdesign_skill.setTargetVal(array[2]*SkillScaleFactor);
        sounddesign_skill.setTargetVal(array[3]*SkillScaleFactor);
    }
    

    public void setID(int val){
        ID = val;
    }

    public void SetIDChanger(changeDisplayEmployeeID changer){
        ID_changer = changer;
    }

    public void setTargetY(float y){
        smoothMover.setTargetY(y);
    }    

    private void checkIfListItemExists(){
        //Falls der zugehörige Mitarbeiter nicht mehr ausgewählt ist, muss dieses Objekt zerstört werden.
        if(HiredEmployees_object.isHired(ID) == false){
            SelfDestruct selfDestructScript = GetComponent<SelfDestruct>();
            selfDestructScript.execute();
        }
    }

    private int getItemIndex(){
        return HiredEmployees_object.getItemIndex(ID);
    }

    public void DeleteItemFromList(){
        //Wenn "x" gedrückt wird, um diesen Mitarbeiter zu entfernen, muss bei HiredEmployees der Wert dieser Mitarbeiter ID auf false gestellt werden.
        if (deleteOrderSent == false){
            deleteOrderSent = true;
            HiredEmployees_object.set(ID,false);
        }
    }

    public void setStartX(float x){
        startX = x;
    }

    public void setStartY(float y){
        startY = y;
    }

    public void setHireListObject(HiredEmployees list){
        HiredEmployees_object = list;
        x_button.setHireListObject(list);
    }

    public void setTopOfList(float y){
        topOfListY = y;
    }

    public void setDistanceBetweenItems(float y){
        YDistanceBetweenItems = y;
    }

    public void SetDisplayName(string name){
        ListItem_Text.text = name;
    }

    public void SetAvatar(Sprite img){
        avatar.sprite = img;

    }

    public int GetID(){
        return ID;
    }

}
