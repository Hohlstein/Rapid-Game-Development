using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public TextMeshProUGUI selectedEmployeeText;

    public void OnButtonClick()
    {
        string buttonText = GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(buttonText);
        selectedEmployeeText.text = buttonText;
    }
}
