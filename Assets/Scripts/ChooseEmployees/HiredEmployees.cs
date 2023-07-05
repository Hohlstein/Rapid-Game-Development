/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiredEmployees : MonoBehaviour
{
    /*
    Diese Klasse merkt sich, welche Personen (zurzeit) als Angestellte ausgewählt sind.
    Diese Information wird im hired dictionary gespeichert.
    */
    public GameObject HireListItem_prefab;
    public Canvas canvas;
    public EmployeeInfo infosource;
    public changeDisplayEmployeeID ID_changer;
    public GameObject hireList_parent;
    private Dictionary<int,bool> hired;
    private List<int> added_order;
    private int n;

    // Start is called before the first frame update
    public void resetList()
    {
        /*
        Überschreibt die gespeicherte Datenbank und trägt für alle IDs ein, dass sie noch nicht eingestellt sind.
        */
        added_order = new List<int>();
        hired = new Dictionary<int,bool>();
        for (int i = 0; i < n; i++)
        {
            hired[i] = false;
        }
    }

    public Dictionary<int,bool> getHireList(){
        return hired;
    }

    public bool isHired(int ID){
        return hired[ID];
    }

    public void set(int ID, bool val){
        if (val == true){
            added_order.Add(ID);
            GameObject instantiatedPrefab = Instantiate(HireListItem_prefab, canvas.transform);
            HireList_ItemHandler itemHandler = instantiatedPrefab.GetComponent<HireList_ItemHandler>();
            itemHandler.transform.SetParent(hireList_parent.transform);
            itemHandler.setID(ID);
            itemHandler.setStartX(1710);
            itemHandler.setStartY(50);
            itemHandler.setTopOfList(856);
            itemHandler.setDistanceBetweenItems(-215);
            itemHandler.setHireListObject(this);
            itemHandler.SetIDChanger(ID_changer);
            itemHandler.SetDisplayName(infosource.getValueString(ID,"firstName") + " " + infosource.getValueString(ID,"lastName")[0]+".");
            itemHandler.SetAvatar(infosource.GetAvatar(ID));
            float[] skillArray = {infosource.getValueFloat(ID,"codingskill"),infosource.getValueFloat(ID,"gamedesignskill"),infosource.getValueFloat(ID,"graphicdesignskill"),infosource.getValueFloat(ID,"sounddesignskill")};
            itemHandler.SetSkillLevels(skillArray);          

            
        }
        else{
            added_order.RemoveAt(getItemIndex(ID));
        }
        hired[ID] = val;
    }

    public void setListLength(int number){
        /*
        Von außen wird die Information eingetragen, wieviele Personen es insgesamt zur Auswahl gibt.
        Dies ist so gelöst, damit man in Zukunft leichter neue Personen hinzufügen kann, ohne den Wert von Hand aktualisieren zu müssen.
        */
        n = number;
    }

    public int getNumberOfSelectedEmployees(){
        /*
        Zählt die Anzahl Personen, die aktuell als Angestellte ausgewählt sind.
        */
        int output = 0;
        for (int i = 0; i < n; i++)
        {
            if (hired[i]){
                output++;
            }
        }
        return output;
    }

    public int getItemIndex(int ID){
        if (isHired(ID)){
            for (int i = 0; i < added_order.Count; i++)
            {
             if (added_order[i] == ID){
                return i;
             }   
            }
            return 0;
        }
        else{
            return 0;
        }
    }

}
