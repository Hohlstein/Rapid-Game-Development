/*
Autor: ChatGPT, Bearbeitet von Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public string playback;
    public Sprite play;
    public Sprite pause;
    public void PlaySingle(AudioClip clip){
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayList(List<AudioClip> list, string player)
    {
        playback = player;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundList(list));
    }

    private System.Collections.IEnumerator PlaySoundList(List<AudioClip> soundList)
    {
        for (int i = 0; i < soundList.Count; i++)
        {
            if (playback != "NULL"){
                audioSource.clip = soundList[i];
                audioSource.Play();

                yield return new WaitForSeconds(audioSource.clip.length);
            }
        }
        playback = "NULL";
        

    }

    public void Stop(){
        audioSource.Stop();
        playback = "NULL";

    }

    public string WhoIsPlaying(){
        return playback;
    }
}
