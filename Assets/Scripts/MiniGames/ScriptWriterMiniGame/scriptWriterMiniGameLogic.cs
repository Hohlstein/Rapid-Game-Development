using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWriterMiniGameLogic : MonoBehaviour
{

    public Countdown timer;
    private int timer_seconds = 60;
    
    // Start is called before the first frame update
    void Start()
    {

        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
