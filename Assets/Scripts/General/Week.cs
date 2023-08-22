using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week : MonoBehaviour
{
     [SerializeField]
    public int weekNumber;

    // Start is called before the first frame update
    void Start()
    {
        weekNumber = 1;
        DontDestroyOnLoad(this.gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextWeek(){
        weekNumber = weekNumber +1 ;
    }

    public int getWeek(){
        return weekNumber;
    }

    public void setWeek(int w) {
        weekNumber = w;
    }
}
