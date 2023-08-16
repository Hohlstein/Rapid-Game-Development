using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeek : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void nextWeek(){
        GameObject[] employeeGameObjects = GameObject.FindGameObjectsWithTag("mitarbeiter"); 
         for (int i = 0; i < employeeGameObjects.Length; i++)
        {
            Mitarbeiter current_employee = employeeGameObjects[i].GetComponent<Mitarbeiter>();
            current_employee.ResetAllHours();
            Debug.Log(current_employee.getWorkingHours());
        }

        GameObject obj = GameObject.Find("WeekInfo");
        Week week = obj.GetComponent<Week>();
        week.nextWeek();

        SceneManagement.changeScene("Chat");
    }
}
