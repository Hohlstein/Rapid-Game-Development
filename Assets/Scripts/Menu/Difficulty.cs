using UnityEngine;
using UnityEngine.UI;

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

public class Difficulty : MonoBehaviour
{
    public GameObject[] difficultyImages;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public Button okButton;
    public static string selectedDiffi = "SelectedDifficulty";

    private int currentIndex = 0;
    private DifficultyLevel selectedDifficulty;

    private void Start()
    {
        UpdateDisplayedImage();
        UpdateArrowVisibility();
        okButton.onClick.AddListener(OnOkButtonClicked);
    }

    private void UpdateDisplayedImage()
    {
        for (int i = 0; i < difficultyImages.Length; i++)
        {
            if (i == currentIndex)
                difficultyImages[i].SetActive(true);
            else
                difficultyImages[i].SetActive(false);
        }
    }

    private void UpdateArrowVisibility()
    {
        leftArrow.SetActive(currentIndex != 0);
        rightArrow.SetActive(currentIndex != difficultyImages.Length - 1);
    }

    public void LeftArrowButton()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = 0;
        UpdateDisplayedImage();
        UpdateArrowVisibility();
    }

    public void RightArrowButton()
    {
        currentIndex++;
        if (currentIndex >= difficultyImages.Length)
            currentIndex = difficultyImages.Length - 1;
        UpdateDisplayedImage();
        UpdateArrowVisibility();
    }

    public void OnOkButtonClicked()
    {
        selectedDifficulty = (DifficultyLevel)currentIndex;
        PlayerPrefs.SetString("SelectedDifficulty", selectedDifficulty.ToString());
        PlayerPrefs.SetInt("ShowTutorialInfoBoxes",1);
        SceneManagement.changeScene("HireList");
    }
}