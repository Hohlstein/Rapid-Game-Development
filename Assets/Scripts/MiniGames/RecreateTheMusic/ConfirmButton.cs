/*
Autor: Klaus Wiegmann
*/

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
    private List<AudioClip> user_solution;
    // Update is called once per frame
    void Update()
    {
        UpdateUserSolution();
        if (user_solution.Count == 0){
            button.interactable = false;
        }
        else{
            button.interactable = true;
        }
    }

    public void Clicked(){
        UpdateUserSolution();
        if (CheckUserAnswer(user_solution,GetSolution())){
            minigame_ender.EndNow(85,"Sehr gut gemacht, aber irgendwie auch nicht, bro.","SoundDesign");
        }   
        else{
            Debug.Log("INCORRECT!");
        }
    }

    private void UpdateUserSolution(){
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
        if (user_solution.Count != real_solution.Count){
            return false;
        }

        for (int i = 0; i < user_solution.Count; i++)
        {
            if (user_solution[i] != real_solution[i]){
                return false;
            }
        }
        return true;

    }
}
