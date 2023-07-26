using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LuckResultDisplay : MonoBehaviour
{
    enum Category
    {
        Coding,
        GameDesign,
        GraphicDesign,
        SoundDesign
    }
    private Dictionary<Category,List<(string,string,string)>> games = new Dictionary<Category,List<(string,string,string)>>();

    public TextMeshProUGUI Minigame_title;
    public TextMeshProUGUI Minigame_desc;
    public GameObject Play_Obj;
    public StartMiniGame Play_button;
    void Start()
    {
        Minigame_title.text = "";
        Minigame_desc.text = "";
        Play_Obj.SetActive(false);
        SetGames();
    }
    
    public void ShowResult(string category){
        Category chosenCategory = MapStringToCategory(category);
        List<(string,string,string)> possibleGames = games[chosenCategory];
        System.Random random = new System.Random();
        int randomInt = random.Next(0, possibleGames.Count-1);
        (string,string,string) chosenGame = possibleGames[randomInt];
        Minigame_title.text = chosenGame.Item1;
        Minigame_desc.text = chosenGame.Item2;
        string MiniGameScene = chosenGame.Item3;
        Play_button.SetTargetScene(MiniGameScene);
        Play_Obj.SetActive(true);
    }

    private void SetGames(){
        //Um ein neues Minigame hinzufügen: z.B. in CodingGames neuen (string,string,string) Tuple hinzufügen.
        //String 1 ist der Minigame Name, 2 ist die Beschreibung und 3 ist der Name der Scene des Games.
        List<(string,string,string)> CodingGames = new List<(string,string,string)>();
        CodingGames.Add(("[Coding Game]","[Coding Game Description]","CodingGame"));
        List<(string,string,string)> GameDesignGames = new List<(string,string,string)>();
        GameDesignGames.Add(("[Game Design Game]","[Game Design Game Description]","GameDesignGame"));
        List<(string,string,string)> GraphicDesignGames = new List<(string,string,string)>();
        GraphicDesignGames.Add(("[Graphic Design Game]","[Graphic Design Game Description]","GraphicDesignGame"));
        List<(string,string,string)> SoundDesignGames = new List<(string,string,string)>();
        SoundDesignGames.Add(("Recreate the Music","Use the playback button to listen to the music you must recreate.\n\nYou're given samples which must be placed into the box at the bottom, in their correct order. You can listen to samples by clicking on them.\n\nWhen you're done and you think your order is correct, click the confirmation button.","RecreateTheMusicMiniGame"));

        games.Add(Category.Coding,CodingGames);
        games.Add(Category.GameDesign,GameDesignGames);
        games.Add(Category.GraphicDesign,GraphicDesignGames);
        games.Add(Category.SoundDesign,SoundDesignGames);
    }

    private Category MapStringToCategory(string x){
        x = x.ToLower();
        if (x == "coding"){
            return Category.Coding;
        }
        if (x == "gamedesign" || x == "game design"){
            return Category.GameDesign;
        }
        if (x == "graphicdesign" || x == "graphic design"){
            return Category.GraphicDesign;
        }
        if (x == "sounddesign" || x == "sound design"){
            return Category.SoundDesign;
        }
        Debug.LogError("Could not convert "+x+" to a Category enum!");
        return Category.Coding;
    }
    

    
}
