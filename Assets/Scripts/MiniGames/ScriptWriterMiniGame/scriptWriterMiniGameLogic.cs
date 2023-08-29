using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scriptWriterMiniGameLogic : MonoBehaviour
{
    public TMP_InputField textfield;
    public TMP_Text leftText;
    public Countdown timer;
    private int timer_seconds = 60;
    private int  characterNumber = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    switch(gameObject.GetComponent<DifficultyManager>().GetLevelInt()){
            case 1:
            timer_seconds = 300;
            break;
            case 2:
            timer_seconds = 120;
            break;
            case 3:
            timer_seconds = 60;
            break;
            default:
            break;
        }
        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkText(){
        if(leftText.text == textfield.text){
             this.GetComponent<EndMiniGame>().EndNow(100, "Very Good Job!", "gamedesign");
        }
        if(leftText.text.StartsWith(textfield.text)){
            characterNumber = textfield.text.Length;
            return;
        }
        else{
         calculatePoints();
        }

    }

    public void calculatePoints(){
           if(characterNumber < 10){
                this.GetComponent<EndMiniGame>().EndNow(0, "Not the very model of a modern script writer.", "gamedesign");
            }
            else if(characterNumber <50){
                this.GetComponent<EndMiniGame>().EndNow(25, "Good Job!", "gamedesign");
            }else if(characterNumber <100){
                this.GetComponent<EndMiniGame>().EndNow(50, "Good Job!", "gamedesign");
            }else if(characterNumber <150){
                this.GetComponent<EndMiniGame>().EndNow(50, "Good Job!", "gamedesign");
            }else if(characterNumber >200){
                this.GetComponent<EndMiniGame>().EndNow(100, "Very Good Job!", "gamedesign");
            }
    }


}
