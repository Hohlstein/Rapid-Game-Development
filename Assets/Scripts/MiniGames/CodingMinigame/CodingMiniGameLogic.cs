using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System;


public class CodingMiniGameLogic : MonoBehaviour
{
    public List<GameObject> codeSnippetlist = new List<GameObject>();
   
    public Countdown timer;
   


    private GameObject neededCodeSnippet;
    private System.Random rand = new System.Random();
    private int neededId = 0;
    private int timer_seconds = 30;
    public GameObject neededCodeSnippetspawnPoint;

    void Start()
    {

            
            neededCodeSnippet = codeSnippetlist[rand.Next(0, codeSnippetlist.Count)];
            neededCodeSnippet = Instantiate(neededCodeSnippet, neededCodeSnippetspawnPoint.transform);
            neededCodeSnippet.GetComponent<Button>().enabled = false;
            neededCodeSnippet.GetComponent<SortingGroup>().sortingOrder = 2;
            neededId = neededCodeSnippet.GetComponent<CodeSnippet>().getId();
          
            timer.SetRemainingSeconds(timer_seconds);
            timer.Unfreeze();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test(int id){
        if(id != neededId) {
            timer_seconds -= 5;
            timer.SetRemainingSeconds(timer_seconds);
            timer.Unfreeze();

        }
        if(id == neededId ){
            if(timer.GetRemainingSeconds() == "30" ||timer.GetRemainingSeconds() =="29"||timer.GetRemainingSeconds() =="28" )
            {
                this.GetComponent<EndMiniGame>().EndNow(100, "Very Good Job!", "coding");
            }else if(timer.GetRemainingSeconds().Length == 2 && timer.GetRemainingSeconds()[0] == '2'){
                    this.GetComponent<EndMiniGame>().EndNow(75, " Good Job!", "coding");
            }else if (timer.GetRemainingSeconds().Length == 2 && timer.GetRemainingSeconds()[0] == '1'){
                    this.GetComponent<EndMiniGame>().EndNow(50, "Good Job!", "coding");
            }else if (timer.GetRemainingSeconds().Length == 1){
                    this.GetComponent<EndMiniGame>().EndNow(25, "Good Job!", "coding");
            }
        }
        else{
            Debug.Log("Not Found");
        }
    }


    

}
