using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateDM : MonoBehaviour {

    public new GameObject gameObject;
    // Update is called once per frame
    public void ToggleDMOn()
    {
        gameObject.SetActive(true);
    }
    public void ToggleDMOff()
    {
        gameObject.SetActive(false);
    }
}
