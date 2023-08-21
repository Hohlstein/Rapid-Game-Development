using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioPlayer : MonoBehaviour
{
    //Dieser Komponente wird im Unity Editor eine beliebige Anzahl an (UI) Sound Clips zugeteilt.
    public List<AudioClip> clips;

    public void TriggerSound(int index){
        if (index < 0 ||index >= clips.Count){
            //Zuerst wird überprüft, ob der gewünschte Index in der Sound Clip Liste vorhanden ist.
            if (clips.Count == 0){
                Debug.LogError("Error: Tried to play UI sound with index "+index+", but this UIAudioPlayer has no clips added to its list!");
            }
            else{
                Debug.LogError("Error: Tried to play UI sound with index "+index+", but that index was out of range. Max index for this object: "+(clips.Count-1).ToString());

            }
        }
        else{
            //Falls er vorhanden ist, wird dieser Index der Liste abgespielt.
            CreateAudioSource(clips[index]);
        }
    }

    private void CreateAudioSource(AudioClip clip){
        //Damit der Spieler beliebig oft/schnell auf einen Button klicken kann, ohne dass der UI Sound abgehackt wird, wird für jeden Sound ein neues audioObject instanziiert,
        //welches nur dazu da ist, den einen AudioClip abzuspielen. Dieses Objekt wird, sobald der Sound abgespielt wurde, wieder gelöscht um Speicher zu sparen und keinen
        //Memory Leak zu verursachen. 
        GameObject audioObject = new GameObject("UIAudioPlayer");
        UIAudioInstanceManager audioSource = audioObject.AddComponent<UIAudioInstanceManager>();
        audioSource.Play(clip);
    }

}
