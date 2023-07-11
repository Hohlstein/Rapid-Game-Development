/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMMG_PreviewPlayback : MonoBehaviour
{
    public MusicMG_PreviewManager manager;
    public Button button;
    public SoundPlayer soundplayer;
    public Image image;
    public Sprite play_sprite;
    public Sprite pause_sprite;
    private bool playback;

    void Start(){
        playback = false;
    }

    void Update(){
        if (manager.GetNumberOfPlacedSamples() > 0){
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
        if (soundplayer.WhoIsPlaying() == "user"){
            image.sprite = pause_sprite;
        }
        else{
            image.sprite = play_sprite;
            playback = false;
        }
    }

    public void Stop(){
        playback = false;
        soundplayer.Stop();
    }

    public void Clicked(){
        if (playback == false){
            playback = true;
            List<MusicSample_Main> sampleList = manager.GetSampleList();
            List<AudioClip> sampleClips = new List<AudioClip>();
            for (int i = 0; i < sampleList.Count; i++)
            {
                sampleClips.Add(sampleList[i].GetClip());
            }
            soundplayer.PlayList(sampleClips,"user");
        }
        else{
            Stop();
        }
   }



}
