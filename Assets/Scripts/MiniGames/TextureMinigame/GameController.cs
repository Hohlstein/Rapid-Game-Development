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
    public UIAudioPlayer UISounds;

    public List<Sprite> gameTextures = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessTexture, secondGuessTexture;

    public Countdown timer; 
    private float timer_seconds;

    public EndMiniGame minigame_ender;

    

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
        gameGuesses = gameTextures.Count / 4;
        Debug.Log("There are" + gameGuesses);
        string diff = PlayerPrefs.GetString("SelectedDifficulty");
        GetLevel(GetLevelInt());

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
        UISounds.TriggerSound(0);
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
            Debug.Log("This is count guess number" + countGuesses);
            StartCoroutine(CheckIfTexturesMatch());
        }

    }

    IEnumerator CheckIfTexturesMatch() {
        yield return new WaitForSeconds (.5f);
        if(firstGuessTexture == secondGuessTexture) {
            UISounds.TriggerSound(1);
            yield return new WaitForSeconds (1f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            UISounds.TriggerSound(3);
            CheckIfGameIsFinished();
        } else {
            UISounds.TriggerSound(2);
            yield return new WaitForSeconds (.5f);
            btns[firstGuessIndex].image.sprite = coveredTexture;
            btns[secondGuessIndex].image.sprite = coveredTexture;
        }
        yield return new WaitForSeconds (.5f);
        firstGuess = secondGuess = false;
    }
    
    void CheckIfGameIsFinished() {
        countCorrectGuesses++;
        Debug.Log("This is correct guess number" + countCorrectGuesses);
        if(countCorrectGuesses == gameGuesses) {
            Debug.Log("Game Finished");
            Debug.Log("It took you" + countGuesses + "many guess(es) to finish the game");
            int result_score = Mathf.RoundToInt((timer.DisplaySeconds/timer.Seconds)*100);
            string result_message = "No message here.";
            minigame_ender.EndNow(result_score,result_message,"GraphicDesign");
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

    public void GetLevel(int level){
        Debug.Log("The level is " + level);
        SetSamplesAndTimer(level);
        timer.SetRemainingSeconds(timer_seconds);
        timer.Unfreeze();
    }

    private void SetSamplesAndTimer(int level){
        if (level == 1){
            timer_seconds = 240;
        }
        if (level == 2) {
            timer_seconds = 120;
        }
        if (level == 3){
            timer_seconds = 50;
        }
    }

    // Start is called before the first frame update
    public int GetLevelInt(){
        //Die im DifficultyMenu festgelegte Schwierigkeit wird aus technischen Gründen in einen int übersetzt.
        string diff = PlayerPrefs.GetString("SelectedDifficulty");
        Debug.Log("Diffulty Manager level is" + diff);
        if(diff=="Easy"){
            return 1;
        }
        if(diff=="Medium"){
            return 3;
        }
        if(diff=="Hard"){
            return 3;
        }
        Debug.LogError("Difficulty val "+diff+"unknown, couldn't load level data!");
        return 999;
    }

   


}


    

