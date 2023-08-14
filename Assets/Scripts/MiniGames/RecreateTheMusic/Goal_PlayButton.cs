//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal_PlayButton : MonoBehaviour
{
    //Dieser Button ist dafür verantwortlich, die Melodie, die nachgeahmt werden soll, abzuspielen.
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
        //Falls gerade die Zielmelodie abgespielt wird, wechselt dieser Button zum pause Sprite und berechnet, wie weit das Playback fortgeschritten ist.
        if (player.WhoIsPlaying() == "goal"){
            button_image.sprite = pause;
            playback = true;
            float timeSoFar = Time.time - startTime;
            progressbar.setCurrentVal((timeSoFar/PlaybackLength)*100);
            progressbar.setTargetVal((timeSoFar/PlaybackLength)*100);
        }
        else{
            //Sonst wechselt er auf den Play Sprite, um anzuzeigen, dass er angeklickt werden kann.
            button_image.sprite = play;
            playback = false;
            progressbar.setCurrentVal(0);
            progressbar.setTargetVal(0);
        }
    }

    public void Clicked(){
        //Falls der Button angeklickt wird, während die Zielmelodie abgespielt wird, muss diese gestoppt werden.
        if (playback){
            player.Stop();
        }
        else{
            //Sonst wird diese gestartet.
            PlaybackLength = CalcPlaybackLength();
            startTime = Time.time;
            //Dem Audio Player wird die AudioClip Liste für die Zielmelodie übergeben, sowie die Information, dass er gerade die Zielmelodie abspielt.
            player.PlayList(spawner.GetSolution(),"goal");
        }
    } 

    private float CalcPlaybackLength(){
        //Die Längen der einzelnen AudioClips werden zusammengerechnet, um die Gesamtlänge des Zielmelodie zu berechnen.
        float output = 0;
        List<AudioClip> solution = spawner.GetSolution();
        for (int i = 0; i < solution.Count; i++)
        {
            output += solution[i].length;
        }
        return output;
    }

}
