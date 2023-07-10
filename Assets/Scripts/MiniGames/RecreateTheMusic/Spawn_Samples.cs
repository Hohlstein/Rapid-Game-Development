using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Samples : MonoBehaviour
{
    public GameObject sample_prefab;
    public int sample_count;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sample_count; i++)
        {
            GameObject sample_instance = Instantiate(sample_prefab);
            MusicSample_Main sample_main = sample_instance.GetComponent<MusicSample_Main>();
            sample_main.GetReady(i);
        }
    }

}
