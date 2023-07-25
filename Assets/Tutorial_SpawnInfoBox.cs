using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_SpawnInfoBox : MonoBehaviour
{
    public GameObject InfoBox_prefab;
    private List<string> done_scenes = new List<string>();

    // Start is called before the first frame update
 

    void Update(){
        Scene scene = SceneManager.GetActiveScene();
        if (done_scenes.Contains(scene.name) == false){
            done_scenes.Add(scene.name);
            WakeUp(scene);
        }
    }

    private void WakeUp(Scene scene){
    {
        string scene_name = scene.name;
        Debug.Log("Received Start!  " + scene_name);
        DontDestroyOnLoad(gameObject);
        Canvas canvas = GetComponent<Canvas>();
        if (PlayerPrefs.GetInt("ShowTutorialInfoBoxes") == 1){
            GameObject infobox_obj = Instantiate(InfoBox_prefab, transform.position, Quaternion.identity);
            Canvas canvas_obj = FindObjectOfType<Canvas>();
            infobox_obj.transform.SetParent(canvas_obj.transform);
            InfoBox_Manager infobox = infobox_obj.GetComponent<InfoBox_Manager>();
            
            infobox.Prepare(scene_name);
        }
    }
    }
}
