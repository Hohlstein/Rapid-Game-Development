using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    public static void changeScene()
    {   
        PerformReset();
        SceneManagement.changeScene("MainMenu");
    }

    public static void PerformReset(){
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allGameObjects)
        {
            obj.transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(obj, SceneManager.GetActiveScene());
        }
    }
}
