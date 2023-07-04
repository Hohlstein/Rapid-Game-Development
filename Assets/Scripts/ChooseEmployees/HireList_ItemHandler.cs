/*
Author: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireList_ItemHandler : MonoBehaviour
{
    private int ID;
    public HiredEmployees HiredEmployees_object;
    public float startX;
    public float startY;
    public float topOfListY;
    public float YDistanceBetweenItems;
    
    
    public SmoothMove smoothMover;
    

    // Start is called before the first frame update
    void Start()
    {
        smoothMover.setCurrentX(startX);
        smoothMover.setCurrentY(startY);
    }

    // Update is called once per frame
    void Update()
    {
        checkIfListItemExists();
        smoothMover.setTargetX(startX);
        smoothMover.setTargetY(topOfListY + YDistanceBetweenItems*getItemIndex());
    }

    public void setID(int val){
        ID = val;
    }

    public void setTargetY(float y){
        smoothMover.setTargetY(y);
    }    

    private void checkIfListItemExists(){
        if(HiredEmployees_object.isHired(ID) == false){
            SelfDestruct selfDestructScript = GetComponent<SelfDestruct>();
            selfDestructScript.execute();
        }
    }

    private int getItemIndex(){
        return HiredEmployees_object.getItemIndex(ID);
    }

    public void setStartX(float x){
        startX = x;
    }

    public void setStartY(float y){
        startY = y;
    }

    public void setHireListObject(HiredEmployees list){
        HiredEmployees_object = list;
    }

    public void setTopOfList(float y){
        topOfListY = y;
    }

    public void setDistanceBetweenItems(float y){
        YDistanceBetweenItems = y;
    }

}
