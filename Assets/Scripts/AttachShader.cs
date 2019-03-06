using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AttachShader : MonoBehaviour
{
    public GameObject myObject;
    public List<GameObject> childrenList = new List<GameObject>();

    // AttachScript description
    // finds out if named object has script added to it already
    // if it doesnt then it adds it
    // if it does then it stops the function

    public void Start()
    {
        AttachScripts();
    }

    public void AttachScripts()
    {
        myObject = GameObject.Find("MyObject");
        Transform[] children = GetComponentsInChildren<Transform>(true);

        if (childrenList == null)
        {
            childrenList = new List<GameObject>();
        }

        foreach (Transform child in children)
        {
            childrenList.Add(child.gameObject);
        }

        #region Old Code
        //if (myObject.name == "MyObject" && myObject.GetComponentInChildren<Transform>(true))
        //{
        //    myObject.AddComponent<OnePlaneCuttingControllerVR>();
        //    myObject.AddComponent<AttachMaterial>();
        //}
        //else if (myObject.name != "MyObject")
        //{
        //    print("Object has script already");
        //    return;
        //}
        #endregion

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {

            if (renderers != null)
            {
                renderers[i].gameObject.AddComponent<OnePlaneCuttingControllerVR>();
                renderers[i].gameObject.AddComponent<AttachMaterial>();
            }

            else if (renderers == null)
            {
                break;
            }

        }

    }

    #region Old Code
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
    #endregion
}