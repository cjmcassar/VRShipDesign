using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EALocation : MonoBehaviour {

    public GameObject ThisObject;
    public GameObject LeftController;

	// Use this for initialization
	void Start ()
    {
        thisObjectLocation();

    }
	
	// Update is called once per frame
	public void thisObjectLocation()
    {
        ThisObject = this.gameObject;
        LeftController = GameObject.Find("Controller (left)");
        ThisObject.transform.position = LeftController.transform.position;
	}
}
