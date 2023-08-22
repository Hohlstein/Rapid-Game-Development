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
    // Start is called before the first frame update
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
        if(id == neededId ){
            
           
            this.GetComponent<EndMiniGame>().EndNow(100, "Good Job!", "Coding");
        }
        else{
            Debug.Log("Not Found");
        }
    }


    

}
