using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultWeekSceneManager : MonoBehaviour
{
    public static void changeScene(string newScene)
    {   
        int weekNumber = GameObject.Find("WeekInfo").GetComponent<Week>().getWeek();
        if (weekNumber >= 5) {
            SceneManager.LoadScene("Endscreen");
        }
        SceneManager.LoadScene(newScene);
    }
}
