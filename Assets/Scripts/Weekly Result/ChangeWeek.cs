using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeWeek : MonoBehaviour
{
    private bool gameovertime = false;
    private List<Mitarbeiter> Hired_Employee_Objects;

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
        int weekNumber = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        TestGameOver();
        if (gameovertime) {
            SceneManagement.changeScene("Endscreen");
            return;
        }
        if (weekNumber >= 5) {
            SceneManagement.changeScene("Cutscene");
            return;
        }
        week.nextWeek();

        SceneManagement.changeScene("WeekStartScreen");
    }

    public void TestGameOver() {
        GameObject obj = GameObject.Find("FinalizedHiredEmployeeList");
        FinalizeEmployeeList finalizeEmployeeList = obj.GetComponent<FinalizeEmployeeList>();
        Hired_Employee_Objects = finalizeEmployeeList.GetEmployeeList();
        foreach(Mitarbeiter mitarbeiter in Hired_Employee_Objects){
            Debug.Log("GAME OVER STRESS:" + mitarbeiter.getStressLevel());
            if (mitarbeiter.getStressLevel() >= 30) {
                SceneManagement.changeScene("Endscreen");
                gameovertime = true;
            }
        }
    }
}
