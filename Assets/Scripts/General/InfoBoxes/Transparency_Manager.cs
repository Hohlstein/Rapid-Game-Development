/*
Autor: ChatGPT
Edtior: Klaus Wiegmann
*/
using UnityEngine;
using UnityEngine.UI;

public class Transparency_Manager : MonoBehaviour
{
    public Image imageComponent;
    private Color originalColor;

    // Initial transparency (0 = fully transparent, 1 = fully opaque)
    public float initialTransparency = 1.0f;

    private void Start()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();

        if (imageComponent != null)
        {
            // Store the original color with the initial transparency
            originalColor = imageComponent.color;
            originalColor.a = initialTransparency;

            // Set the initial transparency
            imageComponent.color = originalColor;
        }
        else
        {
            Debug.LogError("Image component not found on the GameObject.");
        }
    }

    // Function to set the transparency during runtime
    public void SetTransparency(float x)
    {
        // Clamp the input value between 0 and 1
        float clampedValue = Mathf.Clamp01(x);

        if (imageComponent != null)
        {
            // Update the alpha value of the color with the new transparency
            Color newColor = originalColor;
            newColor.a = clampedValue;

            // Apply the new color to the Image component
            imageComponent.color = newColor;
        }
        else
        {
            Debug.LogError("Image component not found on the GameObject.");
        }
    }
}
