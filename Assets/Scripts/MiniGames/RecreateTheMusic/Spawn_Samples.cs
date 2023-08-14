//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawn_Samples : MonoBehaviour
{
    //Dieses Skript erhökt von LevelData die Samples, die gespawned werden müssen. 
    //Diese werden dann in einer zufälligen Reihenfolge instanziiert und ihnen werden alle Eigenschaften übermittelt, die sie benötigen.
    public GameObject sample_prefab;
    public Transform set_parent;
    public MusicMG_PreviewManager preview_manager;
    public SoundPlayer soundplayer;
    public LevelData leveldata;
    public DifficultyManager difficultymanager;

    private Dictionary<int,(string, AudioClip)> SampleData;
    private List<AudioClip> Solution;


    // Start is called before the first frame update
    void Start()
    {
        bool[] bool_array = new bool[2];
        bool_array[0] = true;
        bool_array[1] = false;

        LoadLevel(difficultymanager.GetLevelInt());
        ICollection<int> SampleDataKeys = SampleData.Keys;
        List<int> RandomIndexOrder = GetRandomizedIntList(0,SampleDataKeys.Count);
        int count = 0;
        foreach (int key in SampleDataKeys)
        {
            int index = RandomIndexOrder[count];
            //Da für jedes Sample auch ein Schatten gespawned werden muss, wird das zweite Argument (ob es ein Schatten ist oder nicht) einmal auf true und einmal auf
            //false gesetzt. So wird im Grunde jedes Sample zweimal gespawned, wobei einmal ein Schatten statt ein ziehbares Sample gespawned wird.
            for (int bool_choice = 0; bool_choice <= 1; bool_choice++)
            {
                string sampletype = SampleData[key].Item1;
                AudioClip audioclip = SampleData[key].Item2;
                SpawnSample(index, bool_array[bool_choice],sampletype,soundplayer,audioclip);   
            }  
            count++;
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

    private List<int> GetRandomizedIntList(int x, int y){
        List<int> output = new List<int>();
        System.Random random = new System.Random();
        while (output.Count < y-x){
            int num = random.Next(x,y);
            if (output.Contains(num) == false){
                output.Add(num);
            }
        }
        return output;
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
