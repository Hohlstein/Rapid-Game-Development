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
        Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayList(List<AudioClip> list, string player)
    {
        playback = player;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundList(list));
    }

    private IEnumerator PlaySoundList(List<AudioClip> audioClips)
    {
        for (int i = 0; i < audioClips.Count; i++)
        {
            if (playback != "NULL")
            audioSource.clip = audioClips[i];

            // Preload the audio data
            audioSource.clip.LoadAudioData();

            audioSource.Play();

            // Wait until the current audio clip finishes playing
            yield return new WaitForSeconds(audioSource.clip.length-0.03f);
            if (playback == "NULL"){
                yield break;
            }
        }

        // All audio clips have been played
        Debug.Log("Finished playing audio list.");
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
