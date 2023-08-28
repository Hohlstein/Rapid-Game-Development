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
    public Sprite GameOver;

    public bool gameovertime = false;

    private List<Mitarbeiter> Hired_Employee_Objects;

    // Start is called before the first frame update
    void Start()
    {
        float finalStress = CalculateStressLevel();
        float finalProgress = CalculateOverallProgress();

        TestGameOver();
        if (gameovertime) {
            GetComponent<Image>().sprite = GameOver;
            return;
        }

        if (finalProgress < 400 && finalStress > 15) {
            GetComponent<Image>().sprite = NoStar;
            return;
        }

        if (finalStress > 15) {
            GetComponent<Image>().sprite = OneStar;
            return;
        }

        if (finalStress < 15) {
            GetComponent<Image>().sprite = TwoStar;
            return;
        }

        if (finalProgress >= 400 && finalStress < 15) {
            GetComponent<Image>().sprite = ThreeStar;
            return;
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

    public void TestGameOver() {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            if (mitarbeiter.getStressLevel() >= 30) {
                GetComponent<Image>().sprite = GameOver;
                gameovertime = true;
            }
        }
    }

    
}
