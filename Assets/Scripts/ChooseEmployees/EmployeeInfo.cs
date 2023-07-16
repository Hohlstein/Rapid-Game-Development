/*
Author: Klaus Wiegmann
*/
using UnityEngine;
using System.Collections.Generic;

public class EmployeeInfo : MonoBehaviour
{

    /*
    Dieses Skript sucht zuerst nach GameObjekten mit "mitarbeiter" Tag, um diese in seine Datenbank aufzunehmen.
    Später können über Getter Funktionen die Profilwerte der Mitarbeiter abgefragt werden.
    */

    private GameObject[] employeeGameObjects;
    public HiredEmployees HiredEmployees;
    private Mitarbeiter[] employees_list;
    private Dictionary<int, Mitarbeiter> people = new Dictionary<int, Mitarbeiter>();


    public void Start(){
        employeeGameObjects = GameObject.FindGameObjectsWithTag("mitarbeiter"); 
        Debug.Log("Found "+employeeGameObjects.Length.ToString()+ " employees!");
        ConvertGameObjectsToEmployees(); 
        for (int i = 0; i < employees_list.Length; i++)
        {
            int current_id = employees_list[i].getID();
            people[current_id] = employees_list[i];
            Debug.Log("Added "+employees_list[i].ToString());
        }
        HiredEmployees.setListLength(employees_list.Length);
        HiredEmployees.resetList();
    } 

    public string getValueString(int ID,string key){
        key = key.ToLower();
        string output = "NULL";
        if (key == "firstname"){
            output = people[ID].getFirstName().ToString();
        }
        if (key == "lastname"){
            output = people[ID].getLastName().ToString();
        }
        if (key == "nickname"){
            output = people[ID].getNickName().ToString();
        }
        if (key == "age"){
            output = people[ID].getAge().ToString();
        }
        if (key == "relationshipstatus"){
            output = people[ID].getRelationshipStatus().ToString();
        }
        if (key == "bio"){
            output = people[ID].getBio().ToString();
        }
        if (key == "codingskill"){
            output = people[ID].getCodingSkill().ToString();
        }
        if (key == "gamedesignskill"){
            output = people[ID].getGameDesignSkill().ToString();
        }
        if (key == "graphicdesignskill"){
            output = people[ID].getGraphicDesignSkill().ToString();
        }
        if (key == "soundesignskill"){
            output = people[ID].getSoundDesignSkill().ToString();
        }
        if (key == "stresslevel"){
            output = people[ID].getStressLevel().ToString();
        }
        if (output == "NULL"){
            Debug.Log("Requested "+key+" from employees, but that key is unknown!");
        }
        return output;
    }

    public float getValueFloat(int ID,string key){
        float output = 256;
        if (key == "codingskill"){
            output = people[ID].getCodingSkill();
        }
        if (key == "gamedesignskill"){
            output = people[ID].getGameDesignSkill();
        }
        if (key == "graphicdesignskill"){
            output = people[ID].getGraphicDesignSkill();
        }
        if (key == "sounddesignskill"){
            output = people[ID].getSoundDesignSkill();
        }
        if (key == "stresslevel"){
            output = people[ID].getStressLevel();
        }
        return output;
    }

    public int getWorkingHours(int ID) {
        return people[ID].getWorkingHours();
    }

    private void ConvertGameObjectsToEmployees(){
        employees_list = new Mitarbeiter[employeeGameObjects.Length];
        for (int i = 0; i < employeeGameObjects.Length; i++)
        {
            employees_list[i] = employeeGameObjects[i].GetComponent<Mitarbeiter>();
        }
    }

    public int getNumberOfPeople(){
        return employees_list.Length;
    }
    
    public Sprite GetAvatar(int ID){
        return people[ID].GetAvatar();
    }

    public Mitarbeiter getMitarbeiterObject(int ID){
        return people[ID];
    }
    public void SetValueInteger(int ID, string key, int value)
    {
        if (people.ContainsKey(ID))
        {
            Mitarbeiter employee = people[ID];

            if (key == "workinghours")
            {
                employee.setWorkinghours(value);
            }
        }
    }

}