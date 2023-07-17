using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualisation : MonoBehaviour
{

    public EmployeeInfo infoSource;
    private List<Mitarbeiter> Hired_Employee_Objects;
    
    public TMP_Text CodingValue;
    public TMP_Text GameDesignValue;
    public TMP_Text GraphicDesignValue;
    public TMP_Text SoundDesignValue;

    public PercentageBar CodingSkill;
    public PercentageBar GameDesignSkill;
    public PercentageBar GraphicDesignSkill;
    public PercentageBar SoundDesignSkill;
    // Start is called before the first frame update
    void Start()
    {
        float coding = FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , 1f);
        float gamedesign = FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), 1f);
        float graphicdesign = FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), 1f);
        float sounddesign = FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), PlayerPrefs.GetFloat("MiniGameBoost"));
        
        /*CodingSkill.setCurrentVal(4000);
        GameDesignSkill.setCurrentVal(4000);
        GraphicDesignSkill.setCurrentVal(4000);
        SoundDesignSkill.setCurrentVal(4000);*/

        CodingSkill.setTargetVal(coding);
        GameDesignSkill.setTargetVal(gamedesign);
        GraphicDesignSkill.setTargetVal(graphicdesign);
        SoundDesignSkill.setTargetVal(sounddesign);

        CodingValue.text = (coding*4000/100).ToString() + "%";
        GameDesignValue.text = (gamedesign*4000/100).ToString() + "%";
        GraphicDesignValue.text = (graphicdesign*4000/100).ToString() + "%";
        SoundDesignValue.text = (sounddesign*4000/100).ToString() + "%";
    
    }

    

    float CalculateCodingTime() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getCodingSkill();
        }
        return saver;
    }

    float CalculateGameDesignTime() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getGameDesignSkill();
        }
        return saver;
    }
    

    float CalculateGraphicDesignTime() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getGraphicDesignSkill();
        }
        return saver;
    }

    float CalculateSoundDesignTime() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getSoundDesignSkill();
        }
        return saver;
    }

   float CalculateCodeWork() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getCodingHours();
        }
        return saver;
    }
    
    float CalculateGameWork() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getGameDesignHours();
        }
        return saver;
    }

    float CalculateGraphicWork() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getGrapicDesignHours();
        }
        return saver;
    }

    float CalculateSoundWork() {
        float saver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            saver += mitarbeiter.getSoundDesignHours();
        }
        return saver;
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
    

    float FinalCalculation(float x, float y, float z) {
        return x*y*z;
    }

}

