/*
Author: Fabian Wiehn
*/
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ChatInterface : MonoBehaviour{
    public EmployeeInfo employeeInfo;
    public List<TextMeshProUGUI> employeeNames;
    public HiredEmployees hiredEmployees;

    private int numberOfPeople;

    private void Start() {
        //Decommented once connected to other scenes 
        //HiredEmployees = GameObject.Find("INFO_HireList"); 
        FillHireList(); //temp method development only (will be removed later once HireList scene passes on information)
        UpdateTextFields();
    }

    private void UpdateTextFields() {
        Dictionary<int,bool> hireList = hiredEmployees.getHireList();
        foreach(TextMeshProUGUI employeeName in employeeNames) {
            employeeName.text = "temp";
        }

        int index = 0;
        foreach(KeyValuePair<int,bool> hire in hireList) {
            if(hire.Value == true) {
                employeeNames[index].text = employeeInfo.getValueString(index,"firstName") + " " + employeeInfo.getValueString(index,"lastName");
                index++;
            }   
       }
    }
    public void FillHireList() {
        for(int i= 0; i < 4; i++) {
            hiredEmployees.set(i,true);
        }
    }
}

