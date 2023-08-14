//Autor: Klaus Wiegmann

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    //Dieses Skript dient nur dazu, beim Container rechts das Sprite zu ändern, sobald das Minispiel festgelegt wurde.
    
    public Image img;
    public List<Sprite> sprites;
    

    public void changeSprite(int x){
        if (x < 0 || x > sprites.Count){
            Debug.LogError("Tried to change container's sprite to a sprite index outside of range.");
        }
        else{
            img.sprite = sprites[x];
        }
    }
}
