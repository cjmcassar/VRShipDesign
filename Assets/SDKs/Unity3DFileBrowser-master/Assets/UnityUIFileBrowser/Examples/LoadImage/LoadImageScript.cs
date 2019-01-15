// Author: Salvis Poišs (poisins92@gmail.com)
// Feel free to use and modify (and leave some credits :) )!

using UnityEngine;
using UnityEngine.UI;
using System.IO;
using poisins;

/// <summary>
/// Example - show image selected with file browser
/// </summary>
[DisallowMultipleComponent]
public class LoadImageScript : MonoBehaviour
{

    public Image imageField;

    /// <summary>
    /// Open file browser and pass this script as return MonoBehavior
    /// </summary>
    public void OnClickOpenBrowser()
    {
        FileBrowser.OpenFileBrowser(LoadImage);
    }

    /// <summary>
    /// Load image as Unity3D sprite
    /// </summary>
    /// <param name="path">Image path (returned by FileBrowser)</param>
    public void LoadImage(string path) //perform image loading
    {
        Texture2D tex = null;
        byte[] fileData;
        Sprite image = null;

        // if image file found, load it as sprite
        if (File.Exists(path))
        {
            fileData = File.ReadAllBytes(path);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

            image = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f));
        }
        imageField.sprite = image;
    }

}
