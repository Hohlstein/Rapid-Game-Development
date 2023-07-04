using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiredEmployees : MonoBehaviour
{
    /*
    Diese Klasse merkt sich, welche Personen (zurzeit) als Angestellte ausgewählt sind.
    Diese Information wird im hired dictionary gespeichert.
    */
    private Dictionary<int,bool> hired;
    private int n;

    // Start is called before the first frame update
    public void resetList()
    {
        /*
        Überschreibt die gespeicherte Datenbank und trägt für alle IDs ein, dass sie noch nicht eingestellt sind.
        */
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

}
