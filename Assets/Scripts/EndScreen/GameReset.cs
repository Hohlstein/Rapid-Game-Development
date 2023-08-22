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
            Destroy(current_employee);
            Destroy(employeeGameObjects[i]);
            
        }
        GameObject.Find("WeekInfo").GetComponent<Week>().setWeek(1);


        SceneManagement.changeScene("MainMenu");
    }
}
