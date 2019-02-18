﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttachShader : MonoBehaviour
{
    public GameObject myObject;
    

    void Update()
    {
        AttachScript();
    }

    // AttachScript description
    // finds out if named object has script added to it already
    // if it doesnt then it adds it
    // if it does then it stops the function
    private void AttachScript()
    {
        FindObject();
        if (myObject.name == "MyObject" && !myObject.GetComponent<OnePlaneCuttingControllerVR>() && !myObject.GetComponent<AttachMaterial>())
        {
            myObject.AddComponent<OnePlaneCuttingControllerVR>();
            myObject.AddComponent<AttachMaterial>();
        }
        else if (myObject.name != "MyObject" && myObject.GetComponent<OnePlaneCuttingControllerVR>() && myObject.GetComponent<AttachMaterial>())
        {
            print("Object has script already");
            return;
        }
    }

    // FindObject description
    // finds the object after it is in the scene
    // if object is not in the scene then it returns void
    private void FindObject()
    {
        if (GameObject.Find("MyObject") != null)
        {
            myObject = GameObject.Find("MyObject");
        }
        else if (GameObject.Find("MyObject") == null)
        {
            return;
        }
    }


    //TODO figure out a way to choose object layer through GUI
}

