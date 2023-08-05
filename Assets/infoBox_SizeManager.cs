/*
Autor: Klaus Wiegmann
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class infoBox_SizeManager : MonoBehaviour
{
    public Sprite sprite_large;
    public Sprite sprite_medium;
    public Sprite sprite_small;
    public Image img;
    public GameObject OK_button;

    public TMP_Manager title_TMP;
    public TMP_Manager body_TMP;

    public void SetSmall(){
        img.sprite = sprite_small;
        title_TMP.SetLayout(950,50,75,new Vector2(0,303));
        body_TMP.SetLayout(980,50,60,new Vector2(0,185));
        AdaptButton(new Vector2(0,-260),new Vector2(280,156));
        
    }
    public void SetMedium(){
        img.sprite = sprite_medium;
        title_TMP.SetLayout(950,50,75,new Vector2(0,303));
        body_TMP.SetLayout(1200,50,60,new Vector2(0,180));
        AdaptButton(new Vector2(0,-260),new Vector2(280,156));
    }
    public void SetLarge(){
        img.sprite = sprite_large;
        title_TMP.SetLayout(950,50,100,new Vector2(0,385));
        body_TMP.SetLayout(1300,50,70,new Vector2(0,250));
        AdaptButton(new Vector2(0,-320),new Vector2(374,156));
    }

    private void AdaptButton(Vector2 pos, Vector2 size){
        OK_button.transform.localPosition = pos;
        RectTransform buttonRectTransform = OK_button.GetComponent<RectTransform>();
        buttonRectTransform.sizeDelta = size;
    }

}
