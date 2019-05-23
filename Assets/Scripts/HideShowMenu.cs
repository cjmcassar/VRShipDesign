using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMenu : MonoBehaviour {

    public new GameObject gameObject;
	// Update is called once per frame
	public void ToggleMenuOn()
    {
        gameObject.SetActive(false);
    }
    public void ToggleMenuOff()
    {
        gameObject.SetActive(true);
    }
}
