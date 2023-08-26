//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LuckResultDisplay : MonoBehaviour
{
    //Dieses Skript wählt, jenachdem, welche Kategorie das Glücksrad entschieden hat, eins der Minispiele in dieser Kategorie und
    //kümmert sich ums Anzeigen des Namen sowie der Beschreibung des Spiels.
    enum Category
    {
        Coding,
        GameDesign,
        GraphicDesign,
        SoundDesign,
        Special
    }
    private Dictionary<Category,List<(string,string,string)>> games = new Dictionary<Category,List<(string,string,string)>>();

    public TextMeshProUGUI Minigame_title;
    public TextMeshProUGUI Minigame_desc;
    public GameObject Play_Obj;
    public StartMiniGame Play_button;
    void Start()
    {
        //Anfangs werden Name und Beschreibung versteckt, indem sie auf einen leeren String gesetzt werden. Auch der Play Button muss deaktiviert werden.
        Minigame_title.text = "";
        Minigame_desc.text = "";
        Play_Obj.SetActive(false);
    }
    
    public void ShowResult(string category){
        SetGames();
        //Zuerst wird die eingegebene Kategorie, die als String übergeben wurde, zu einem category enum konvertiert, um damit weiterzuarbeiten.
        Category chosenCategory = MapStringToCategory(category);
        SetBonusCategory(category);
        //Die Anzahl Spiele, die es für diese Kategorie gibt wird gezählt und eins von diesen wird zufällig ausgewählt.
        List<(string,string,string)> possibleGames = games[chosenCategory];
        System.Random random = new System.Random();
        int randomInt = random.Next(0, possibleGames.Count-1);
        (string,string,string) chosenGame = possibleGames[randomInt];
        //Nun, da das Spiel ausgewählt wurde, können der Name und die Beschreibung angezeigt werden.
        Minigame_title.text = chosenGame.Item1;
        Minigame_desc.text = chosenGame.Item2;
        string MiniGameScene = chosenGame.Item3;
        //Dem Play Button wird übermittelt, zu welcher Scene (welchem Minigame) er folglich wechseln muss und wird aktiviert.
        Play_button.SetTargetScene(MiniGameScene);
        Play_Obj.SetActive(true);
    }

    private void SetGames(){
        //Um ein neues Minigame hinzufügen: z.B. in CodingGames neuen (string,string,string) Tuple hinzufügen.
        //String 1 ist der Minigame Name, 2 ist die Beschreibung und 3 ist der Name der Scene des Games.
        List<(string,string,string)> CodingGames = new List<(string,string,string)>();
        CodingGames.Add(("[Coding Game]","[Coding Game Description]","CodingMiniGame"));
        List<(string,string,string)> GameDesignGames = new List<(string,string,string)>();
        GameDesignGames.Add(("[Game Design Game]","[Game Design Game Description]","ScriptWriterMiniGame"));
        List<(string,string,string)> GraphicDesignGames = new List<(string,string,string)>();
        GraphicDesignGames.Add(("Texture Memory","A GitHub server issue has created duplicates of all the game textures!\n\nClick textures to open them. Try to find the pairs and open both to solve the duplicate conflict!\nSolve all conflicts to finish the minigame!","TextureMinigame"));
        List<(string,string,string)> SoundDesignGames = new List<(string,string,string)>();
        SoundDesignGames.Add(("Recreate the Music","Use the playback button to listen to the music you must recreate.\n\nYou're given samples which must be placed into the box at the bottom, in their correct order. You can listen to samples by clicking on them.\n\nWhen you're done and you think your order is correct, click the confirmation button.","RecreateTheMusicMiniGame"));
        List<(string,string,string)> SpecialGames = new List<(string,string,string)>();
        SpecialGames.Add(("Fix the coffee machine","[Description here]","CoffeMachineGame"));

        games.Add(Category.Coding,CodingGames);
        games.Add(Category.GameDesign,GameDesignGames);
        games.Add(Category.GraphicDesign,GraphicDesignGames);
        games.Add(Category.SoundDesign,SoundDesignGames);
        games.Add(Category.Special,SpecialGames);
    }

    private Category MapStringToCategory(string x){
        x = x.ToLower();
        x = x.Replace(" ", "");
        Debug.Log("this is " + x);
        if (x == "coding"){
            return Category.Coding;
        }
        if (x == "gamedesign"){
            return Category.GameDesign;
        }
        if (x == "graphicdesign"){
            return Category.GraphicDesign;
        }
        if (x == "sounddesign"){
            return Category.SoundDesign;
        }
        if (x == "special"){
            return Category.Special;
        }
        Debug.LogError("Could not convert "+x+" to a Category enum!");
        return Category.Coding;
    }

    private void SetBonusCategory(string x) {
        x = x.ToLower();
        x = x.Replace(" ", "");
        PlayerPrefs.SetString("LastMinigame", x);
        
    }
    

    
}
