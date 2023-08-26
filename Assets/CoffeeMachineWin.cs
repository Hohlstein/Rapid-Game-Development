//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachineWin : MonoBehaviour
{
    public Countdown clock;

    public void WinGame(){
        EndMiniGame gameFinisher = GetComponent<EndMiniGame>();
        float score = clock.DisplaySeconds / clock.Seconds;
        gameFinisher.EndNow((int)Mathf.Ceil(score*100f),"Do I smell coffee??\nThis will wake up the whole team!","special");
    }
    
}
