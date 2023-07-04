using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public GameObject[] difficultyImages; // Array von Schwierigkeitsbildern, zwischen denen gewechselt wird
    public GameObject leftArrow; // Game-Objekt des linken Pfeils
    public GameObject rightArrow; // Game-Objekt des rechten Pfeils

    private int currentIndex = 0; // Aktueller Index des angezeigten Bildes

    private void Start()
    {
        UpdateDisplayedImage();
        UpdateArrowVisibility();
    }

    // Diese Methode zeigt das entsprechende Schwierigkeitsbild an und versteckt die anderen
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

    // Diese Methode zeigt oder versteckt den linken und rechten Pfeil basierend auf der aktuellen Schwierigkeit
    private void UpdateArrowVisibility()
    {
        if (currentIndex == 0)
            leftArrow.SetActive(false); // Verstecke den linken Pfeil für die einfachste Schwierigkeit
        else
            leftArrow.SetActive(true);

        if (currentIndex == difficultyImages.Length - 1)
            rightArrow.SetActive(false); // Verstecke den rechten Pfeil für die höchste Schwierigkeit
        else
            rightArrow.SetActive(true);
    }

    // Methode für den linken Pfeil-Button
    public void LeftArrowButton()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = 0;
        UpdateDisplayedImage();
        UpdateArrowVisibility();
    }

    // Methode für den rechten Pfeil-Button
    public void RightArrowButton()
    {
        currentIndex++;
        if (currentIndex >= difficultyImages.Length)
            currentIndex = difficultyImages.Length - 1;
        UpdateDisplayedImage();
        UpdateArrowVisibility();
    }
}
