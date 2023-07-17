using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Visualisation : MonoBehaviour
{

    
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
        float coding = FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , 1f)/200;
        float gamedesign = FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), 1f)/200;
        float graphicdesign = FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), 1f)/200;
        float sounddesign = FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/200;
        

        CodingSkill.setTargetVal((float)Math.Round(coding));
        GameDesignSkill.setTargetVal((float)Math.Round(gamedesign));
        GraphicDesignSkill.setTargetVal((float)Math.Round(graphicdesign));
        SoundDesignSkill.setTargetVal((float)Math.Round(sounddesign));

        CodingValue.text = (Math.Round(coding)).ToString() + "%";
        GameDesignValue.text = (Math.Round(gamedesign)).ToString() + "%";
        GraphicDesignValue.text = (Math.Round(graphicdesign)).ToString() + "%";
        SoundDesignValue.text = (Math.Round(sounddesign)).ToString() + "%";
    
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
        float saver = 1f;
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

