/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSample_Main : MonoBehaviour
{
    public enum SampleType
    {
        Short,
        Standard
    }
    public Sprite[] standard_sprites;
    public Sprite[] short_sprites;
    public SmoothMove move;
    public DragAndDropObjects dragdrop;
    public MusicMG_PreviewManager manager;
    public SampleType type;
    public AudioClip audioclip;
    private Button button;
    public bool staticOnly;

    private SoundPlayer soundplayer;
    private int spawn_index;
    private CanvasGroup canvasGroup;
    private int spawn_x;
    private int spawn_y;
    private bool inSetBoxReach;
    private int boxIndex;
    private bool hasBeenPlaced;
    private int number_of_columns = 5;

    private void CalcSpawnLocation(){
        //Die Ausgangsposition wird berechnet, abhängig vom Spawn Index. Sie wird automatsich in Zeilen und Spalten eingereiht.
        spawn_x = ((spawn_index % number_of_columns) - 2) * 256 + 960;
        spawn_y = 540 + 80 - (spawn_index/number_of_columns*80);
    }

    public void GetReady(int x, MusicMG_PreviewManager m, SoundPlayer player, AudioClip clip){
        //Nachdem ein Sample Objekt instanziiert wurde, werden ihm über GetReady viele Informationen übergeben, z.B. der individuelle Spawn Index, das PreviewManager Objekt, 
        //das SoundPlayer Objekt und der individuelle AudioClip.
        spawn_index = x;
        soundplayer = player;
        audioclip = clip;
        manager = m;
        hasBeenPlaced = false;
        canvasGroup = GetComponent<CanvasGroup>();
        button = GetComponent<Button>();
        //Diese Klasse dient sowohl für die Sample Objekte an sich, die sich ziehen lassen, als auch die grauen Schatten, die an den Spawnpositionen bleiben.
        //Bei den Objekten, die für die grauen Schatten zuständig sind, ist staticOnly true. Deshalb können sie nicht angeklickt oder gezogen werden. Ihre
        //graue Farbe wird über SetStaticButtonColors() eingestellt.
        if (staticOnly){
            button.interactable = false;
            SetStaticButtonColors();
            dragdrop.enabled = false;
        }
        CalcSpawnLocation();
        move.setCurrentX(spawn_x);
        move.setCurrentY(spawn_y);
        move.setTargetX(spawn_x);
        move.setTargetY(spawn_y);
        if (staticOnly == false){
            //Falls es sich um ein ziehbares Sample Objekt und keinen Schatten handelt, wird dem manager (der sich um das Ergebnisfeld kümmert) mitgeteilt,
            //dass dieses Sample existiert, damit er darauf zugreifen kann.
            manager.RegisterSample(this);
        }
        Image image = GetComponent<Image>();
        //Die image Komponente wird angepasst, sowohl was die Länge (Standard oder Short) als auch die Farbe angeht. Die Farben sind als einzelne PNGs gespeichert.
        if (type == SampleType.Standard){
            image.sprite = standard_sprites[spawn_index % standard_sprites.Length];
        }
        else{
            image.sprite = short_sprites[spawn_index % short_sprites.Length];
        }
        

    }

    public void Update(){
        if (staticOnly == false){
            //Falls die Instanz kein Sample Schatten ist, wird überprüft, ob das Sample bereits im Feld abgelegt wurde.
            if (hasBeenPlaced){
                //Falls ja, muss das blockRaycasts Attribut im Falle dessen, dass sich der Mauscursor links vom Ergebnisfeld befinden, auf false gesetzt werden,
                //sonst überschneidet sich die Hitbox des linkesten abgelegten Samples mit dem Playback Button.
                Vector3 mousePosition = Input.mousePosition;
                float mouseX = mousePosition.x;
                if (mouseX < 365){
                    canvasGroup.blocksRaycasts = false;
                }
                else {
                    canvasGroup.blocksRaycasts = true;
                }
                button.interactable = false;
            }
            else{
                button.interactable = true;
            }

            if (dragdrop.isBeingDragged()){
                //Falls das Sample gerade gezogen wird und es davor abgelegt war, muss es aus dem Ergebnisfeld entfernt werden.
                if (hasBeenPlaced){
                        manager.RemoveSample(this);
                        hasBeenPlaced = false;
                    }
                //Damit das Objekt beim Herumziehen nicht immer wieder versucht, an seine Spawnposition bzw. seine Position im Ergebnisfeld zurückzukehren, muss die move 
                //komponente pausiert (freezed) werden.
                move.freeze = true;
                //Wird das Objekt über das Feld gehalten, wird "inSetBoxReach" auf true gestellt. Wenn nicht, dann nicht.
                if(transform.position.y < 164){
                    inSetBoxReach = true;
                }
                else
                {
                    inSetBoxReach = false;
                    move.setFriction(75);
                    move.setTargetX(spawn_x);
                    move.setTargetY(spawn_y);
                    
                }
            
            }
            else{
                //Wird das Sample (nicht mehr) gezogen und wurde es bis dahin über das Feld gehalten, wird dem Feld Manager dies mitgeteilt. Er kümmert sich in DropSample() darum,
                //dass das Sample Objekt an die richtige Stelle im Feld abgelegt wird.
                if (inSetBoxReach) {
                    manager.DropSample(this);
                    hasBeenPlaced = true;
                    move.setFriction(35);
                    inSetBoxReach = false;
                    button.interactable = false;
                }
                move.freeze = false;
            }
        }
    }

    public void setType(string x){
        if (x == "standard"){
            type = SampleType.Standard;
        }
        if (x == "short"){
            type = SampleType.Short;
        }
    }

    public float getXPosition(){
        return transform.position.x;
    }

    public bool checkIfInBoxReach(){
        return inSetBoxReach;
    }

    public void setTargetX(float x){
        move.setTargetX(x);
    }

    public void setTargetY(float y){
        move.setTargetY(y);
    }

    public float GetPixelWidth(){

        if (type == SampleType.Short){
            return 115;
        }
        if (type == SampleType.Standard){
            return 230;
        }

        return 0;
        
    }

    public int GetMarkerIndexSpacing(){
        if (type == SampleType.Short){
            return 1;
        }
        if (type == SampleType.Standard){
            return 2;
        }

        return 0;
    }

    public void Clicked(){
        soundplayer.PlaySingle(audioclip);
    }

    public AudioClip GetClip(){
        return audioclip;
    }

    private void SetStaticButtonColors(){
        var buttonColors = button.colors;
        buttonColors.disabledColor = Color.black;
        Color buttonColor = button.image.color;
        buttonColor.a = 0.5f;
        button.image.color = buttonColor;
        button.colors = buttonColors;
    }


}
