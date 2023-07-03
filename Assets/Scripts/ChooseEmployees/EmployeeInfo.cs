using UnityEngine;
using System.Collections.Generic;

public class EmployeeInfo : MonoBehaviour
{

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
        HiredEmployees.resetList(employees_list.Length);
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
}