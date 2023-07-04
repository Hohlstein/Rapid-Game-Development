using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControler : MonoBehaviour
{
    public GameObject DifficultyMenu;
    public GameObject MainMenu;

    void Start()
    {
        DifficultyMenu.SetActive(false);
    }

    public void NewGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DifficultyMenu.SetActive(true);
        MainMenu.SetActive(false);
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
