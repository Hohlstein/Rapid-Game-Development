using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseResult : MonoBehaviour
{
    public Sprite NoStar;
    public Sprite OneStar;
    public Sprite TwoStar;
    public Sprite ThreeStar;

    private List<Mitarbeiter> Hired_Employee_Objects;

    // Start is called before the first frame update
    void Start()
    {
        float finalStress = CalculateStressLevel();
        float finalProgress = CalculateOverallProgress();

        if (finalProgress < 200 && finalStress > 15) {
        GetComponent<Image>().sprite = NoStar;
        return;
        }

        if (finalStress > 15) {
            GetComponent<Image>().sprite = OneStar;
        }

        if (finalStress < 15) {
            GetComponent<Image>().sprite = TwoStar;
        }

        if (finalProgress > 200 && finalStress < 15) {
            GetComponent<Image>().sprite = ThreeStar;
        }

    }

    float CalculateStressLevel() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getStressLevel();
        }
        return saver;
    }

    float CalculateOverallProgress() {
        float saver = 0;
        saver += PlayerPrefs.GetFloat("codingvalue") + PlayerPrefs.GetFloat("gamedesignvalue") + PlayerPrefs.GetFloat("graphicdesignvalue") + PlayerPrefs.GetFloat("sounddesignvalue");
        return saver;
    }

    
}
