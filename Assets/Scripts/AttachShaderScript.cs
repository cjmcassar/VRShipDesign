using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttachShaderScript : MonoBehaviour
{
    public GameObject myObject;


    void Start()
    {
        // if (object has a specific name)
        //{ 
        //then add script to it
        //}

        myObject = GameObject.Find("MyObject");

        AttachScript();

    }

    private void AttachScript()
    {
        if (myObject = GameObject.Find("MyObject"))
        {
            myObject.AddComponent<OnePlaneCuttingController>();

        }
    }
}



 //   // Use this for initialization
 //   void Start ()
 //   {

	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}


