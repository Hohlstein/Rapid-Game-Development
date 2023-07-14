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
    private Image image;

    void Start(){
        image = GetComponent<Image>();
        DisplaySprite = DefaultSprite;
    }

    void Update(){
        SetSize(size);
        GoTo(X_Pos,Y_Pos);
        UpdateSprite();
    }

    public void SetEmployee(Mitarbeiter employee){
        DisplaySprite = employee.GetAvatar();
        UpdateSprite();
    }

    private void UpdateSprite(){
        image.sprite = DisplaySprite;
    }

    public void GoTo(float x, float y){
        Vector3 pos = new Vector3(x,y,0);
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
