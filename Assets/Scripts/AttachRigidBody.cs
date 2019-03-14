using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachRigidBody : MonoBehaviour
{
    public GameObject myObject;

    void Update()
    {
        FindObject();
    }

    /// <AttachScript description>
    /// finds out if named object has script added to it already
    /// if it doesnt then it adds it
    /// if it does then it stops the function
    ///</AttachScript>
    private void AttachScript()
    {
        
        if (myObject.name == "MyObject" && !myObject.GetComponent<RigidBodyScript>())
        {
            myObject.AddComponent<RigidBodyScript>();
        }
        else if (myObject.name != "MyObject" && myObject.GetComponent<RigidBodyScript>())
        {
            print("Object has script already");

        }
    }

    /// <FindObject description>
    /// finds the object after it is in the scene
    /// if object is not in the scene then it returns void
    /// </FindObject>
    private void FindObject()
    {
        if (GameObject.Find("MyObject") != null)
        {
            myObject = GameObject.Find("MyObject");
            AttachScript();
        }
        else if (GameObject.Find("MyObject") == null)
        {
            return;
        }
    }

}