using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {

    public static ColorManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private Color color;

    void OnColorChange(HSBColor color)
    {
        this.color = color.ToColor();
    }

    public Color GetCurrentColor()
    {
        return this.color;
    }


}
