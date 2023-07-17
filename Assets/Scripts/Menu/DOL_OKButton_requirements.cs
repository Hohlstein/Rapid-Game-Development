/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOL_OKButton_requirements : MonoBehaviour
{
    public Button button;

    void Update()
    {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList FinalizedEmployeeHireList = obj.GetComponent<FinalizeEmployeeList>();
        if (FinalizedEmployeeHireList == null){
            Debug.LogError("Couldn't find the finalized employee hire list object. Did you load into this scene directly, instead of through HireList.unity?");
        }
        else{
            List<Mitarbeiter> employees = FinalizedEmployeeHireList.GetEmployeeList();
            button.interactable = requirementMet(employees);
        }
    }
    private bool requirementMet(List<Mitarbeiter> employees){
        foreach (var employee in employees)
            {
                if (employee.AreCategoryHoursAssigned() == false){
                    return false;
                }
            }
        return true;
    }
}
