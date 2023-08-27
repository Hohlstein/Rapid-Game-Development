using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareWallpapers : MonoBehaviour
{
    public List<Sprite> sprites;
    void Start()
    {
        WallpaperList.shared = new List<Sprite>();
        foreach (Sprite wallpaper in sprites)
        {
            WallpaperList.shared.Add(wallpaper);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
