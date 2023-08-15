using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataTexture : MonoBehaviour
{
    
    public Countdown  timer;
    private float timer_seconds;

    
    public void GetLevel(int level){
        SetSamplesAndTimer(level);
        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
    }

    private void SetSamplesAndTimer(int level){
        if (level == 1){
            timer_seconds = 240;
        }
        if (level == 2) {
            timer_seconds = 90;
        }
        if (level == 3){
            timer_seconds = 30;
        }
    }

}

