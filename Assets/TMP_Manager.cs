/*
Autor: Klaus Wiegmann
*/
using TMPro;
using UnityEngine;

public class TMP_Manager : MonoBehaviour

{
    private TextMeshProUGUI tmpComponent;

    void Start(){
        tmpComponent = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string input){
        tmpComponent.text = input;
    }

    public void SetLayout(float width, float height, float fontSize, Vector3 localPosition)
    {
        // Get the TextMeshProUGUI component attached to this GameObject

        if (tmpComponent != null)
        {
            // Set the width and height
            RectTransform rectTransform = tmpComponent.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                Vector2 newSize = new Vector2(width, height);
                rectTransform.sizeDelta = newSize;
            }
            else
            {
                Debug.LogError("RectTransform component not found on the TMP object.");
            }

            // Set the font size
            tmpComponent.fontSize = fontSize;

            // Set the local position
            transform.localPosition = localPosition;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on the TMP object.");
        }
    }
}
