//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    public MusicMG_PreviewManager manager;
    public Button button;
    public Spawn_Samples spawner;
    public EndMiniGame minigame_ender;
    public Countdown timer;
    public MiniGame_Incorrect incorrect_text;
    public UIAudioPlayer UIAudio;
    private List<AudioClip> user_solution;
    // Update is called once per frame
    void Update()
    {
        UpdateUserSolution();
        //Falls der Spieler noch keine Samples ins Feld gezogen hat, kann auch kein Ergebnis überprüft werden. Deshalb muss der Button in diesem Fall deaktiviert werden.
        if (user_solution.Count == 0){
            button.interactable = false;
        }
        else{
            button.interactable = true;
        }
    }

    public void Clicked(){
        UpdateUserSolution();
        //Es wird überprüft, ob die AudioClips der Lösung und der vom Spieler eingereichten Samples gleich sind. 
        //Wenn ja, hat der Spieler das MiniSpiel erfolgreich abgeschlossen.
        if (CheckUserAnswer(user_solution,GetSolution())){
            UIAudio.TriggerSound(1);
            int result_score = Mathf.RoundToInt((timer.DisplaySeconds/timer.Seconds)*100);
            string result_message = "Great job! This will surely help your audio department!";
            minigame_ender.EndNow(result_score,result_message,"SoundDesign");
        }   
        else{
            //Wenn nicht, wird auf dem Bildschirm "INCORRECT" angezeigt.
            UIAudio.TriggerSound(0);
            Debug.Log("INCORRECT!");
            incorrect_text.Flash();
        }
    }

    private void UpdateUserSolution(){
        //Hier wird die eingereichte Lösung des Spielers eingeholt. Wichtig: Es werden die zu den Samples zugehörigen AudioClips, nicht die Samples selbst eingeholt.
        //D.h. wenn mehrere Samples den selben AudioClip enthalten, ist egal, in welcher Reihenfolge sie eingesetzt wurden, da sie gleich klingen.
        List<MusicSample_Main> user_samples = manager.GetSampleList();
        List<AudioClip> output = new List<AudioClip>();
        for (int i = 0; i < user_samples.Count; i++)
        {
            output.Add(user_samples[i].GetClip());
        }
        user_solution = output;
    }

    private List<AudioClip> GetSolution(){
        return spawner.GetSolution();
    }

    private bool CheckUserAnswer(List<AudioClip> user_solution, List<AudioClip> real_solution){
        //Falls die Lösung eine andere Zahl AudioClips vorsieht, als abgegeben wurden, kann das Ergebnis nicht stimmen.
        if (user_solution.Count != real_solution.Count){
            return false;
        }

        //Es wird für jeden AudioClip verglichen, ob er sich mit der Musterlösung deckt.
        for (int i = 0; i < user_solution.Count; i++)
        {
            if (user_solution[i] != real_solution[i]){
                return false;
            }
        }
        return true;

    }
}
