//Autor: Klaus Wiegmann
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMiniGame : MonoBehaviour
{
    
    private string next_scene;
    

    public void SetTargetScene(string x){
        next_scene = x;
    }

    public void Clicked(){
        if (next_scene == null){
            //Dies sollte nie vorkommen, da der Play Button erst aktiviert wird, nachdem das Spiel entschieden wurde. Dennoch ist dieser Fall zur Sicherheit beachtet.
            Debug.LogError("Next Scene hasn't been set!");
        }
        else{
            //Dem Play Button wurde die Scene für's Minigame übermittelt und nun wird dazu gewechselt.
            if (next_scene == "RecreateTheMusicMiniGame" || next_scene == "TextureMinigame"){
                SceneManagement.changeScene(next_scene);
            }
            else{
                Debug.Log("ATTENTION!!! Should switch to: "+next_scene+", but switching to RecreateTheMusicMiniGame, since other minigames are in development.");
                SceneManagement.changeScene("TextureMinigame");
            }
            
        }
    }

}
