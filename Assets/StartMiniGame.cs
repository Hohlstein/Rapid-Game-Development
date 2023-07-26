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
            Debug.LogError("Next Scene hasn't been set!");
        }
        else{
            Debug.Log("ATTENTION!!! Should switch to: "+next_scene+", but switching to RecreateTheMusicMiniGame, since other minigames are in development.");
            //SceneManagement.changeScene(next_scene);
            SceneManagement.changeScene("RecreateTheMusicMiniGame");
        }
    }

}
