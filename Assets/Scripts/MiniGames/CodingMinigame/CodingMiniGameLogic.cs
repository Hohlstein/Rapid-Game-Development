using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CodingMiniGameLogic : MonoBehaviour
{
    public List<GameObject> codeSnippetlist = new List<GameObject>();
    public List<GameObject> spawnPointlist = new List<GameObject>();
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
            neededId = neededCodeSnippet.GetComponent<CodeSnippet>().getId();
          
            shuffle();
            timer.SetRemainingSeconds(timer_seconds);
            timer.Unfreeze();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void test(int id){
        if(id == neededId ){
            
            shuffle();
            this.GetComponent<EndMiniGame>().EndNow(100, "Good Job!", "Coding");
        }
        else{
            Debug.Log("Not Found");
        }
    }

    private void shuffle(){
         int n = codeSnippetlist.Count;  
            while (n > 1) {  
                 n--;  
                int k = rand.Next(n + 1);  
                GameObject value = codeSnippetlist[k];  
                codeSnippetlist[k] = codeSnippetlist[n];  
                codeSnippetlist[n] = value;  
            }  
        
            for(int i= 0; i<9; i++){
                   codeSnippetlist[i].transform.position = spawnPointlist[i].transform.position;
                 
            }
    }
    

}
