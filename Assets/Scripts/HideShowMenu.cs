using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowMenu : MonoBehaviour {

    public GameObject gameObject;
	// Update is called once per frame
	public void ToggleMenu()
    {
        renderer.enabled = !renderer.enabled;
	}
}
