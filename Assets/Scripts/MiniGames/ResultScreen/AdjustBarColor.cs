/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustBarColor : MonoBehaviour
{
    public Image bar;
    public void SetGameType(string type)
    {
        type = type.ToLower();
        Color targetColor = new Color32(0,0,0,255);
        Dictionary<string,Color> options = new Dictionary<string,Color>();
        options.Add("coding",new Color32(0,52,255,255));
        options.Add("gamedesign",new Color32(255,0,0,255));
        options.Add("graphicdesign",new Color32(18,128,0,255));
        options.Add("sounddesign",new Color32(255,156,0,255));
        options.Add("special",new Color32(255,255,255,255));
        if (options.ContainsKey(type)){
            targetColor = options[type];
        }
        else{
            Debug.Log("The minigame type "+type+" is unknown!");
        }
        bar.color = targetColor;
    }
}
