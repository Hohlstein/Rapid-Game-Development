using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StressText : MonoBehaviour
{
    public TMP_Text StressMention;
    private List<Mitarbeiter> Hired_Employee_Objects;
    // Start is called before the first frame update
    void Start()
    {
        RenameStressText(CalculateStressLevel(), StressMention);
    }

    float CalculateStressLevel() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getStressLevel();
        }
        Debug.Log("STRESSLEVEL: "+ saver);
        return saver;
    }

    void RenameStressText(float stress, TMP_Text StressLevel) {
        StressLevel.text = "No stressed team in sight!";
        if (stress > 15) {
            StressLevel.text = "Your team is stressed! Try to go easy on them.";
            return;
        } if (stress > 20) {
            StressLevel.text = "Your team is very stressed! Keep this up and someone might just leave your company.";
        }
    }


 
}
