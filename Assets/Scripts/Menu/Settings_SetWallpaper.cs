using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_SetWallpaper : MonoBehaviour
{
    public int WallpaperIndex;

    public void SetWallpaper(){
        PlayerPrefs.SetInt("Wallpaper",WallpaperIndex);
    }
}
