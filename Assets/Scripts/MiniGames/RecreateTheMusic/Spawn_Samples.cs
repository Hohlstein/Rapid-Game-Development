/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn_Samples : MonoBehaviour
{
    public GameObject sample_prefab;
    public Transform set_parent;
    public MusicMG_PreviewManager preview_manager;
    public SoundPlayer soundplayer;
    public LevelData leveldata;
    private Dictionary<int,(string, AudioClip)> SampleData;
    private List<AudioClip> Solution;


    // Start is called before the first frame update
    void Start()
    {
        bool[] bool_array = new bool[2];
        bool_array[0] = true;
        bool_array[1] = false;

        LoadLevel(1);
        ICollection<int> SampleDataKeys = SampleData.Keys;
        int index = 0;
        foreach (int key in SampleDataKeys)
        {
            for (int j = 0; j <= 1; j++)
            {
                string sampletype = SampleData[key].Item1;
                AudioClip audioclip = SampleData[key].Item2;
                SpawnSample(index, bool_array[j],sampletype,soundplayer,audioclip);   
            }  
            index++;
        }

            
    }
    

    private void SpawnSample(int index, bool staticOnly, string type,SoundPlayer soundplayer,AudioClip audioclip){
        Vector3 position = new Vector3(0f, 0f, 0f);
        Quaternion rotation = Quaternion.identity;
        Transform parent = set_parent;
        GameObject sample_instance = Instantiate(sample_prefab,position,rotation,parent);
        MusicSample_Main sample_main = sample_instance.GetComponent<MusicSample_Main>();
        sample_main.staticOnly = staticOnly;
        sample_main.setType(type);
        sample_main.GetReady(index,preview_manager,soundplayer,audioclip);
    }

    private void LoadLevel(int level){
        (Dictionary<int,(string, AudioClip)>,List<AudioClip>) data = leveldata.GetLevel(level);
        SampleData = data.Item1;
        Solution = data.Item2;
    }

    public List<AudioClip> GetSolution(){
        return Solution;
    }

}
