/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMiniGame : MonoBehaviour
{
    public GameObject prefab;

    public void EndNow(int score, string message, string gametype){
        /* Gametype muss sein: Coding / GraphicDesign / GameDesign / SoundDesign
        */
        GameObject instance = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        MiniGameResultContainer container = instance.GetComponent<MiniGameResultContainer>();
        container.SetScore(score);
        container.SetMessage(message);
        container.SetGameType(gametype);
        SceneManager.LoadScene("MiniGameResultScreen");
    }
}
