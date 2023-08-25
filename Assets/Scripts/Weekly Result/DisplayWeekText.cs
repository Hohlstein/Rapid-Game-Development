using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayWeekText : MonoBehaviour
{
    public TMP_Text ResultText;
    // Start is called before the first frame update
    void Start() { 
        int weekNumber = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        Debug.Log("It is week " + weekNumber);
        DisplayText(ResultText, weekNumber);
    }

    void DisplayText(TMP_Text text, int week) {
        ResultText.text = "Result: Week " + week;

    }
}
