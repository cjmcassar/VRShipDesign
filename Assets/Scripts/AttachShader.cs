using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttachShader : MonoBehaviour
{
    public GameObject myObject;
    


    // AttachScript description
    // finds out if named object has script added to it already
    // if it doesnt then it adds it
    // if it does then it stops the function
    void OnCollisionEnter(Collision collision)
    {
        myObject = GameObject.Find("MyObject");
        Transform[] children = GetComponentsInChildren<Transform>(true);
        if (myObject.name == "MyObject" && myObject.GetComponentInChildren<Transform>())
        {
            myObject.AddComponent<OnePlaneCuttingControllerVR>();
            myObject.AddComponent<AttachMaterial>();
        }
        else if (myObject.name != "MyObject")
        {
            print("Object has script already");
            return;
        }
    }

    //void Update()
    //{
    //    FindObject();
    //}


    // FindObject description
    // finds the object after it is in the scene
    // if object is not in the scene then it returns void
    //private void FindObject()
    //{
    //    if (GameObject.Find("MyObject") != null)
    //    {
    //        myObject = GameObject.Find("MyObject");

    //    }
    //    else if (GameObject.Find("MyObject") == null)
    //    {
    //        return;
    //    }
    //}


    //TODO figure out a way to choose object layer through GUI
}

