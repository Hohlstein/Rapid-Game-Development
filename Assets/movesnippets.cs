using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System;

public class movesnippets : MonoBehaviour
{

    public GameObject  snippetspawnPoint;
    public List<GameObject> spawnPointlist;
    private bool newinstance = true;
    private int speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        shuffle();
        switch(gameObject.GetComponent<DifficultyManager>().GetLevelInt()){
            case 1:
            break;
            case 2:
            speed = 3;
            break;
            case 3:
            speed = 5;
            break;
            default:
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y >600 && newinstance){
           
            Instantiate(gameObject, snippetspawnPoint.transform.position,Quaternion.identity, snippetspawnPoint.transform);
            newinstance = false;
        }
        else{
              transform.position = transform.position + Vector3.up * speed *Time.deltaTime;
             
        }

        if(transform.localPosition.y > 1500){
            Destroy(gameObject);
        }
    }


    private void shuffle(){
    int n = 9;
    System.Random rand = new System.Random();
    while (n > 1) 
        {
            int k = rand.Next(n--);
            GameObject temp = spawnPointlist[n];
            spawnPointlist[n] = spawnPointlist[k];
            spawnPointlist[k] = temp;
        }
    int i = 0;
    foreach (Transform child in transform)
    {
    child.position = spawnPointlist[i].transform.position + new Vector3(0, transform.position.y, 0);
    i++;
    }

        
    }
}
