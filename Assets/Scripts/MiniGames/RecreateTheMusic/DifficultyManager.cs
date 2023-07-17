using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int GetLevelInt(){
        string diff = PlayerPrefs.GetString("SelectedDifficulty");
        if(diff=="Easy"){
            return 1;
        }
        if(diff=="Medium"){
            return 3;
        }
        if(diff=="Hard"){
            return 3;
        }
        Debug.LogError("Difficulty val "+diff+"unknown, couldn't load level data!");
        return 999;
    }
    
}
