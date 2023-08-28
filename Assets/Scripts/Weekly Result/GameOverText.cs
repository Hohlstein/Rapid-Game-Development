using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public TMP_Text GameOverMention;
    private List<Mitarbeiter> Hired_Employee_Objects;
    // Start is called before the first frame update
    void Start()
    {
        GameOverWarnings();
    }

    void GameOverWarnings() {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            if (mitarbeiter.getStressLevel() >= 25) {
                GameOverMention.text = "At least one of your employees is almost at their breaking point. Better go easy on them.";
            }
            if (mitarbeiter.getStressLevel() >= 30) {
                GameOverMention.text = "You have reached the point of no return. The resignation of at least one of your employees is imminent.";
            }
        }
    }
}
