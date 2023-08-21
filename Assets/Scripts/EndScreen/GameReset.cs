using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public static void changeScene()
    {
        GameObject[] employeeGameObjects = GameObject.FindGameObjectsWithTag("mitarbeiter"); 
         for (int i = 0; i < employeeGameObjects.Length; i++)
        {
            Mitarbeiter current_employee = employeeGameObjects[i].GetComponent<Mitarbeiter>();
            current_employee.ResetAllHours();
            Debug.Log(current_employee.getWorkingHours());
        }
        GameObject.Find("WeekInfo").GetComponent<Week>().setWeek(0);


        SceneManagement.changeScene("MainMenu");
    }
}
