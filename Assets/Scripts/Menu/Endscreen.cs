using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscreen : MonoBehaviour
{
    public GameObject[] gameObjects;

    public void OnOkButtonClicked()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void SetFinalResult()
    {
        DeactivateAllGameObjects();

        int percentage = PlayerPrefs.GetInt("FinalResultPercentage", 0);

        if (percentage >= 0 && percentage <= 100)
        {
            if (percentage <= 20)
            {
                gameObjects[0].SetActive(true);
            }
            else if (percentage <= 33)
            {
                gameObjects[1].SetActive(true);
            }
            else if (percentage <= 66)
            {
                gameObjects[2].SetActive(true);
            }
            else
            {
                gameObjects[3].SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Invalid percentage! Percentage should be between 0 and 100.");
        }
    }

    private void DeactivateAllGameObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
    public void Start()
    {
        SetFinalResult();
    }
}
