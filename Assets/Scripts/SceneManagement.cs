using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement :  MonoBehaviour
{
    public static void changeScene(string newScene)
    {   
        SceneManager.LoadScene(newScene);
    }
}
