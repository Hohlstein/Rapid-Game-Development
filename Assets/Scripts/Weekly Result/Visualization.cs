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


    private float coding;
    private float gamedesign;
    private float graphicdesign;
    private float sounddesign;

    private float codesaver;
    private float gamesaver;
    private float graphicsaver;
    private float soundsaver;

    private float bulb;


    // Start is called before the first frame update
    void Start()
    {
        LookForWeek();
        Debug.Log("Coding value: " + coding);
        codesaver = PlayerPrefs.GetFloat("codingvalue");
        gamesaver = PlayerPrefs.GetFloat("gamedesignvalue");
        graphicsaver = PlayerPrefs.GetFloat("graphicdesignvalue");
        soundsaver = PlayerPrefs.GetFloat("sounddesignvalue");

        CalculateForVisual();

        Debug.Log("FINAL GAME DESIGN VALUE: " + gamedesign);

        CodingSkill.setTargetVal((float)Math.Round(coding));
        GameDesignSkill.setTargetVal((float)Math.Round(gamedesign));
        GraphicDesignSkill.setTargetVal((float)Math.Round(graphicdesign));
        SoundDesignSkill.setTargetVal((float)Math.Round(sounddesign));

        CodingValue.text = (Math.Round(coding)).ToString() + "%";
        GameDesignValue.text = (Math.Round(gamedesign)).ToString() + "%";
        GraphicDesignValue.text = (Math.Round(graphicdesign)).ToString() + "%";
        SoundDesignValue.text = (Math.Round(sounddesign)).ToString() + "%";

        PlayerPrefs.SetFloat("codingvalue", coding);
        PlayerPrefs.SetFloat("gamedesignvalue", gamedesign);
        PlayerPrefs.SetFloat("graphicdesignvalue", graphicdesign);
        PlayerPrefs.SetFloat("sounddesignvalue", sounddesign);

        
    
    }

    

    float CalculateCodingTime() {
        float CodingSaver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            CodingSaver += mitarbeiter.getCodingSkill();
        }
        return CodingSaver;
    }

    float CalculateGameDesignTime() {
        float GameDesignSaver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            GameDesignSaver += mitarbeiter.getGameDesignSkill();
        }
        Debug.Log("GameDesign Skills should be 90, but is " + GameDesignSaver);
        return GameDesignSaver;
        
    }
    

    float CalculateGraphicDesignTime() {
        float GraphicDesignSaver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            GraphicDesignSaver += mitarbeiter.getGraphicDesignSkill();
        }
        return GraphicDesignSaver;
    }

    float CalculateSoundDesignTime() {
        float SoundDesignSaver = 0;
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            SoundDesignSaver += mitarbeiter.getSoundDesignSkill();
        }
        return SoundDesignSaver;
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
        Debug.Log("GameDesignHours should be 32, but are" + saver);
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


    float FinalCalculation(float x, float y, float z) {
        return x*y*z;
    }

    void LookForWeek() {
        int weekNumber = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        switch (weekNumber) 
        {
            case 1:
            PlayerPrefs.SetFloat("codingvalue", 0);
            PlayerPrefs.SetFloat("gamedesignvalue", 0);
            PlayerPrefs.SetFloat("graphicdesignvalue", 0);
            PlayerPrefs.SetFloat("sounddesignvalue", 0);
            break;

            default:
            break;
        }
    }

    void CalculateForVisual() {
        Debug.Log("Coding value: " + coding);
        codesaver = PlayerPrefs.GetFloat("codingvalue");
        gamesaver = PlayerPrefs.GetFloat("gamedesignvalue");
        graphicsaver = PlayerPrefs.GetFloat("graphicdesignvalue");
        soundsaver = PlayerPrefs.GetFloat("sounddesignvalue");

        Debug.Log("Gamesaver is" + gamesaver);

        if (PlayerPrefs.GetString("Codingforweekly") == "Codingforweekly") {
        Debug.Log("This is bonus " + PlayerPrefs.GetString("Codingforweekly"));
        coding = codesaver + FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        gamedesign = gamesaver +  FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), 1f)/1000;
        graphicdesign = graphicsaver +  FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), 1f)/1000;
        sounddesign = soundsaver +  FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), 1f)/1000;
        PlayerPrefs.DeleteKey("Codingforweekly");
        
        }

        if (PlayerPrefs.GetString("GameDesignforweekly") == "GameDesignforweekly") {
        Debug.Log("This is bonus " + PlayerPrefs.GetString("GameDesignforweekly"));
        coding = codesaver +  FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , 1f)/1000;
        gamedesign = gamesaver +  FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        graphicdesign = graphicsaver +  FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), 1f)/1000;
        sounddesign = soundsaver + FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), 1f)/1000;
        PlayerPrefs.DeleteKey("GameDesignforweekly");
        }

        if (PlayerPrefs.GetString("GraphicDesignforweekly") == "GraphicDesignforweekly") {
        Debug.Log("This is bonus " + PlayerPrefs.GetString("GraphicDesignforweekly"));    
        coding = codesaver + FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , 1f)/1000;
        gamedesign = gamesaver +  FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), 1f)/1000;
        graphicdesign = graphicsaver + FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        sounddesign = soundsaver + FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), 1f)/1000;
        PlayerPrefs.DeleteKey("GraphicDesignforweekly");
        }

        if (PlayerPrefs.GetString("SoundDesignforweekly") == "SoundDesignforweekly") {
        Debug.Log("This is bonus " + PlayerPrefs.GetString("SoundDesignforweekly"));    
        coding = codesaver +  FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , 1f)/1000;
        gamedesign = gamesaver +  FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), 1f)/1000;
        graphicdesign = graphicsaver + FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), 1f)/1000;
        sounddesign = soundsaver +  FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        PlayerPrefs.DeleteKey("SoundDesignforweekly");
        }

        if (PlayerPrefs.GetString("Specialforweekly") == "Specialforweekly") {
        Debug.Log("This is bonus " + PlayerPrefs.GetString("Specialforweekly"));    
        coding = codesaver + FinalCalculation(CalculateCodingTime(), CalculateCodeWork() , PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        gamedesign = gamesaver + FinalCalculation(CalculateGameDesignTime(), CalculateGameWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        graphicdesign = graphicsaver + FinalCalculation(CalculateGraphicDesignTime(), CalculateGraphicWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        sounddesign = soundsaver +  FinalCalculation(CalculateSoundDesignTime(), CalculateSoundWork(), PlayerPrefs.GetFloat("MiniGameBoost"))/1000;
        PlayerPrefs.DeleteKey("Specialforweekly");
        }
    }

}

