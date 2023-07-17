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
        float MiniGameBoost = (1f+percentage/100f);
        DisplayScore.text = MiniGameBoost.ToString()+"x";
        PlayerPrefs.SetFloat("MiniGameBoost",MiniGameBoost);
        DisplayMessage.text = message;
        DisplayBar.setCurrentVal(0);
        DisplayBar.setTargetVal(percentage);
        results.Recycle();

    }
}
