/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameInfoManager : MonoBehaviour
{
    public TextMeshProUGUI DisplayScore;
    public TextMeshProUGUI DisplayMessage;
    public PercentageBar DisplayBar;
    public AdjustBarColor BarColorSetter;

    private MiniGameResultContainer results;
    private int percentage;
    private string message;
    private string gametype;

    // Start is called before the first frame update
    void Start()
    {
        results = (MiniGameResultContainer)FindObjectOfType(typeof(MiniGameResultContainer));
        gametype = results.GetGameType();
        percentage = results.GetScore();
        message = results.GetMessage();

        BarColorSetter.SetGameType(gametype);
        DisplayScore.text = percentage.ToString() + "%";
        DisplayMessage.text = message;
        DisplayBar.setCurrentVal(0);
        DisplayBar.setTargetVal(percentage);

    }
}
