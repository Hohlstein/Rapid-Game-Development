/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal_PlayButton : MonoBehaviour
{
    public Image button_image;
    public bool playback = false;
    public SoundPlayer player;
    public Spawn_Samples spawner;
    public Sprite play;
    public Sprite pause;
    public PercentageBar progressbar;
    public float PlaybackLength;
    private float startTime;

    void Update(){
        if (player.WhoIsPlaying() == "goal"){
            button_image.sprite = pause;
            playback = true;
            float timeSoFar = Time.time - startTime;
            progressbar.setCurrentVal((timeSoFar/PlaybackLength)*100);
            progressbar.setTargetVal((timeSoFar/PlaybackLength)*100);
        }
        else{
            button_image.sprite = play;
            playback = false;
            progressbar.setCurrentVal(0);
            progressbar.setTargetVal(0);
        }
    }

    public void Clicked(){
        if (playback){
            player.Stop();
        }
        else{
            PlaybackLength = CalcPlaybackLength();
            startTime = Time.time;
            player.PlayList(spawner.GetSolution(),"goal");
        }
    } 

    private float CalcPlaybackLength(){
        float output = 0;
        List<AudioClip> solution = spawner.GetSolution();
        for (int i = 0; i < solution.Count; i++)
        {
            output += solution[i].length;
        }
        return output;
    }

}
