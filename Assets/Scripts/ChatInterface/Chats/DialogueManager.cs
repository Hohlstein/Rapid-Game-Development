using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public List<GameObject> objectsToStay;

    private void Awake()
    {
        foreach (GameObject obj in objectsToStay)
        {
            DontDestroyOnLoad(obj);
        }
    }
}