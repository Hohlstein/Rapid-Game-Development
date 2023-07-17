/*
Author: Fabian Wiehn
*/
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ChatInterface : MonoBehaviour{
    public EmployeeInfo employeeInfo;
    public List<TextMeshProUGUI> employeeNames;
    private List<Mitarbeiter> Hired_Employee_Objects;

    private int numberOfPeople;

    private void Start() {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            Debug.Log("Mitarbeiter in Liste" + mitarbeiter.name);
        }
        UpdateTextFields();
    }

    private void UpdateTextFields() {
        foreach(TextMeshProUGUI employeeName in employeeNames) {
            employeeName.text = "temp";
        }
        int index = 0;
        foreach(Mitarbeiter hired in Hired_Employee_Objects) {
                employeeNames[index].text = hired.getFirstName() + " " + hired.getLastName();
                index++; 
       }
    }
}

