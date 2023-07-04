/*
Author: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKButton_CheckRequirements : MonoBehaviour
{
    public Button button;
    public HiredEmployees HiredEmployees;

    // Update is called once per frame
    void Update()
    {
        /*
        Im Menü müssen genau 4 Angestellte ausgewählt werden. Daher ist der Button nur aktiviert, wenn genau 4 ausgewählt sind.
        */
        if (HiredEmployees.getNumberOfSelectedEmployees() == 4){
            button.interactable = true;
        }
        else{
            button.interactable = false;
        }
    }
}
