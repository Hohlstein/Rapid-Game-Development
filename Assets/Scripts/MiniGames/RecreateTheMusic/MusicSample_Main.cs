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
        spawn_x = ((spawn_index % number_of_columns) - 2) * 256 + 960;
        spawn_y = 540 + 80 - (spawn_index/number_of_columns*80);
    }

    public void GetReady(int x, MusicMG_PreviewManager m, SoundPlayer player, AudioClip clip){
        spawn_index = x;
        soundplayer = player;
        audioclip = clip;
        manager = m;
        hasBeenPlaced = false;
        canvasGroup = GetComponent<CanvasGroup>();
        button = GetComponent<Button>();
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
            manager.RegisterSample(this);
        }
        Image image = GetComponent<Image>();
        if (type == SampleType.Standard){
            image.sprite = standard_sprites[spawn_index % standard_sprites.Length];
        }
        else{
            image.sprite = short_sprites[spawn_index % short_sprites.Length];
        }
        

    }

    public void Update(){
        if (staticOnly == false){
            if (hasBeenPlaced){
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
                if (hasBeenPlaced){
                        manager.RemoveSample(this);
                        hasBeenPlaced = false;
                    }
                move.freeze = true;
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
