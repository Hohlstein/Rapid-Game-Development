/*
Autor: Klaus Wiegmann
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{
    public Sprite DefaultSprite;
    public float X_Pos;
    public float Y_Pos;
    public float size;

    private Sprite DisplaySprite;
    public Image image;

    void Start(){
        //Damit auf jeden Fall etwas angezeigt wird, wird anfangs die Image Komponente auf das festgelegte DefaultSprite gesetzt.
        Image temp_image = GetComponent<Image>();
        if (temp_image != null){
            image = temp_image;
        }
        DisplaySprite = DefaultSprite;
        UpdateSprite();
    }

    void Update(){
        //Die Größe und Position werden am laufenden Band aktualisiert, sodass theoretisch auch von außen gesteuerte Animationen möglich sind.
        SetSize(size);
        GoTo(X_Pos,Y_Pos);
        UpdateSprite();
    }

    public void SetEmployee(Mitarbeiter employee){
        //Ändert den anzuzeigenden Sprite auf den des aktuell ausgewählten Mitarbeiters.
        DisplaySprite = employee.GetAvatar();   
        UpdateSprite();
    }

    private void UpdateSprite(){
        if (DisplaySprite != null){
            image.sprite = DisplaySprite;
        }
    }

    public void GoTo(float x, float y){
        Vector3 pos = new Vector3(x,y);
        transform.localPosition = pos;
    }
    public void SetX(float x){
        X_Pos = x;
    }
    public void SetY(float y){
        Y_Pos = y;
    }

    public void SetSize(float s){
        image.rectTransform.sizeDelta = new Vector2(s, s);
    }
}
