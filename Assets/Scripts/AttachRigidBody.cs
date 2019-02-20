using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachRigidBody : MonoBehaviour
{


    public GameObject myObject;

    // TODO: add function that attaches to any gameobject loaded in the scene and its children
    // TODO(cont.): Maybe the function can be an if statement looking for gameobject with the name "myobject"

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
        if (myObject.name == "MyObject" && !myObject.GetComponent<RigidBodyScript>())
        {
            myObject.AddComponent<RigidBodyScript>();
        }
        else if (myObject.name != "MyObject" && myObject.GetComponent<RigidBodyScript>())
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

}