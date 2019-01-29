using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttachShaderScript : MonoBehaviour
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
        if (myObject.name == "MyObject" && !myObject.GetComponent<OnePlaneCuttingController>())
        {
            myObject.AddComponent<OnePlaneCuttingController>();
        }
        else if (myObject.name != "MyObject" && !myObject.GetComponent<OnePlaneCuttingController>())
        {
            print("Object has script already");
            return;
        }
    }

    // FindObject description
    // finds the object after it is in the scene

    private void FindObject()
    {
        myObject = GameObject.Find("MyObject");

    }


}

