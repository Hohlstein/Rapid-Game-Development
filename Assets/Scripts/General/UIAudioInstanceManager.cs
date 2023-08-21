//Autor: Klaus Wiegmann
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioInstanceManager : MonoBehaviour
{
    private AudioSource audioSource;
    public void Play(AudioClip clip)
    {
        if (clip != null){
            audioSource = gameObject.AddComponent<AudioSource>();
            //Damit Sounds, die zum Szenenwechsel abgespielt werden (z.B. Drücken auf OK Knopf) nicht sofort
            //wieder unterbrochen werden, darf das GameObject beim Szenenwechsel nicht automatisch zerstört werden
            DontDestroyOnLoad(gameObject);
            audioSource.clip = clip;
            audioSource.Play();
            StartCoroutine(DestroyAfterPlayback(clip.length));
        }
        else{
            Debug.LogError("A UIAudioInstanceManager was created, but no clip was given or the clip was invalid!");
        }
    }

    private System.Collections.IEnumerator DestroyAfterPlayback(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
