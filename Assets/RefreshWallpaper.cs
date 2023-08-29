using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshWallpaper : MonoBehaviour
{

    void Update(){
        Image img = GetComponent<Image>();
        if (PlayerPrefs.HasKey("Wallpaper")){
            int Index = PlayerPrefs.GetInt("Wallpaper");
            if (WallpaperList.shared != null && Index < WallpaperList.shared.Count && Index >= 0){
                img.sprite = WallpaperList.shared[Index];
            }
        }
        else{
            if (WallpaperList.shared != null){
                img.sprite = WallpaperList.shared[0];
            }
        }
    }
}