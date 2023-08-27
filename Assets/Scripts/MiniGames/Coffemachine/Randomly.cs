using UnityEngine;

public class Randomly : MonoBehaviour
{
    public GameObject[] gameObjectsToShuffle;
    public GameObject[] gameObjectsToShuffle2;
    private Line[] lines;
    private bool winFlag = false;


    private void Start()
    {
        ShuffleGameObjects();
        ShuffleGameObjects2();
        lines = FindObjectsOfType<Line>();
    }

    private void ShuffleGameObjects()
    {
        int n = gameObjectsToShuffle.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int randomIndex = Random.Range(i, n);

            
            GameObject tempObject = gameObjectsToShuffle[i];
            gameObjectsToShuffle[i] = gameObjectsToShuffle[randomIndex];
            gameObjectsToShuffle[randomIndex] = tempObject;

            
            Vector3 tempPosition = gameObjectsToShuffle[i].transform.position;
            gameObjectsToShuffle[i].transform.position = gameObjectsToShuffle[randomIndex].transform.position;
            gameObjectsToShuffle[randomIndex].transform.position = tempPosition;

        }
    }
    private void ShuffleGameObjects2()
    {
        int n = gameObjectsToShuffle.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int randomIndex = Random.Range(i, n);

          
            GameObject tempObject = gameObjectsToShuffle2[i];
            gameObjectsToShuffle2[i] = gameObjectsToShuffle2[randomIndex];
            gameObjectsToShuffle2[randomIndex] = tempObject;

          
            Vector3 tempPosition = gameObjectsToShuffle2[i].transform.position;
            gameObjectsToShuffle2[i].transform.position = gameObjectsToShuffle2[randomIndex].transform.position;
            gameObjectsToShuffle2[randomIndex].transform.position = tempPosition;
        }
    }

    private void Update()
    {
        if (!winFlag) 
        {
            bool allFinished = true;

            foreach (Line line in lines)
            {
                if (!line.finish)
                {
                    
                    allFinished = false;
                    break;
                }
            }

            if (allFinished)
            {
                CoffeeMachineWin win = GetComponent<CoffeeMachineWin>();
                winFlag = true; 
                win.WinGame();
            }
        }
    }
}