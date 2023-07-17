using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControler : MonoBehaviour
{
 
    void Start()
    {
       
    }

    public void NewGame()
    {
        SceneManagement.changeScene("Difficultymenue");


    }

    public void Continue()
    {
       
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
