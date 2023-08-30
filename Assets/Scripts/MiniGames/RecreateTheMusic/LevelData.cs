//Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public AudioClip[] clips;
    public Countdown  timer;
    private float timer_seconds;
    Dictionary<int,(string, AudioClip)> samples;
    List<int> solution_numbers;

    //Dieses Skript übergibt je nach Schwierigkeitsgrad eine andere Reihe an Samples und eine andere Lösung, sodass hiermit das Level bereitgestellt wird.
    public (Dictionary<int,(string, AudioClip)>,List<AudioClip>) GetLevel(int level){
        Debug.Log("Current level is" + level);
        samples = new Dictionary<int,(string, AudioClip)>();
        List<AudioClip> solution = new List<AudioClip>();
        solution_numbers = new List<int>();
        SetSamplesAndTimer(level);

        for (int i = 0; i < solution_numbers.Count; i++)
        {
            solution.Add(clips[solution_numbers[i]]);
        }

        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
        return (samples,solution);
    }

    private void SetSamplesAndTimer(int level){
        //samples enthält die Samples, die dem Spieler zur verfügung stehen. short bzw. standard beschreibt, wie das Sample angezeigt werden soll (kurzer oder langer Block)
        //Clips[x] gibt an, welchen AudioClip das Samples repräsentiert.
        //Solution Numbers ist die richtige Reihenfolge der AudioClips (!), nicht der Samples. Hierdurch ist die Lösung unabhängig von der Reihenfolge, wenn mehrere Samples
        //den selben AudioClip repräsentieren.
        //Timer_Seconds speichert, wieviele Sekunden dem Spieler zur Verfügung stehen, um das MiniGame zu lösen.
        if (level == 1){
            samples.Add(0,("short",clips[0]));
            samples.Add(1,("standard",clips[2]));
            samples.Add(2,("short",clips[1]));
            samples.Add(3,("standard",clips[2]));
            
            solution_numbers = new List<int>() {2,0,2,1};
            timer_seconds = 60;
        }
        if (level == 3){
            samples.Add(0,("standard",clips[3]));
            samples.Add(1,("short",clips[4]));
            samples.Add(2,("short",clips[3]));
            samples.Add(3,("short",clips[4]));
            samples.Add(4,("short",clips[5]));
            samples.Add(5,("short",clips[6]));
            samples.Add(6,("short",clips[7]));
            samples.Add(7,("short",clips[5]));
            samples.Add(8,("short",clips[8]));

            
            solution_numbers = new List<int>() {3,4,3,4,5,6,7,5,8};
            timer_seconds = 10;
        }
    }

}
