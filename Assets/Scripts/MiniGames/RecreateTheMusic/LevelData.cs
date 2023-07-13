/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public AudioClip[] clips;
    public Countdown  timer;
    private float timer_seconds;

    public (Dictionary<int,(string, AudioClip)>,List<AudioClip>) GetLevel(int level){
        Dictionary<int,(string, AudioClip)> samples = new Dictionary<int,(string, AudioClip)>();
        List<AudioClip> solution = new List<AudioClip>();
        List<int> solution_numbers = new List<int>();
        if (level == 1){
            samples.Add(0,("short",clips[0]));
            samples.Add(1,("standard",clips[2]));
            samples.Add(2,("short",clips[1]));
            samples.Add(3,("standard",clips[2]));
            
            solution_numbers = new List<int>() {2,0,2,1};
            timer_seconds = 60;
        }

        for (int i = 0; i < solution_numbers.Count; i++)
        {
            solution.Add(clips[solution_numbers[i]]);
        }

        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
        return (samples,solution);
    }
}
