/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameResultContainer : MonoBehaviour
{
    private int percentage = 0;
    private string message = "";
    private string gametype = "";

    void Start(){
        DontDestroyOnLoad(this);
    }

    public void SetGameType(string type){
        gametype = type;
    }
    public void SetScore(int n){
        percentage = n;
    }
    public void SetMessage(string s){
        message = s;
    }
    public string GetGameType(){
        return gametype;
    }
    public int GetScore(){
        return percentage;
    }
    public string GetMessage(){
        return message;
    }

    public void Recycle(){
        Destroy(this);
    }

}
