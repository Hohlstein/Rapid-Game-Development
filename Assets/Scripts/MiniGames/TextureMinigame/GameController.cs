using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite coveredTexture;

    public Sprite[] textureCards;

    public List<Sprite> gameTextures = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessTexture, secondGuessTexture;

    

    // Start is called before the first frame update
    void Start()
    {
        btns.AddRange(GameObject.FindGameObjectsWithTag("MemoryButton").Select(X=>X.GetComponent<Button>()));
        for(int i = 0; i < btns.Count; i++) {
            btns[i].image.sprite = coveredTexture;
        }
        AddListeners();
        AddTextures();
        Shuffle(gameTextures);
        gameGuesses = gameTextures.Count / 2;
    }

    void AddTextures() {
        int index = 0;

        for(int i = 0; i < btns.Count; i++){
            if(index == btns.Count / 2) {
                index = 0;
            }

            gameTextures.Add(textureCards[index]);

            index++;
        }

    }

    void AddListeners() {
        foreach(Button btn in btns) {
            btn.onClick.AddListener(() => PickTexture());
        }

    }

    public void PickTexture() {
        if(!firstGuess) {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessTexture = gameTextures[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gameTextures[firstGuessIndex];
            btns[firstGuessIndex].interactable = false;

        } else if(!secondGuess) {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessTexture = gameTextures[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gameTextures[secondGuessIndex];
            btns[firstGuessIndex].interactable = true;
            countGuesses++;
            StartCoroutine(CheckIfTexturesMatch());
        }

    }

    IEnumerator CheckIfTexturesMatch() {
        yield return new WaitForSeconds (.5f);
        if(firstGuessTexture == secondGuessTexture) {
            yield return new WaitForSeconds (.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CheckIfGameIsFinished();
        } else {
            yield return new WaitForSeconds (.5f);
            btns[firstGuessIndex].image.sprite = coveredTexture;
            btns[secondGuessIndex].image.sprite = coveredTexture;
        }
        yield return new WaitForSeconds (.5f);
        firstGuess = secondGuess = false;
    }
    
    void CheckIfGameIsFinished() {
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses) {
            Debug.Log("Game Finished");
            Debug.Log("It took you" + countGuesses + "many guess(es) to finish the game");
        }
    }

    void Shuffle(List <Sprite> list) {
        for(int i = 0; i < 12; i++) {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, 12);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}


    
