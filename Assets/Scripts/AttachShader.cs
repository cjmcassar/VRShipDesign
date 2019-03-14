using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AttachShader : MonoBehaviour
{
    public GameObject myObject;
    public List<GameObject> parentList = new List<GameObject>();

    #region Old Code
    //public void Start()
    //{
    //    AttachScripts();
    //}
    #endregion Old Code

    /// <AttachScript description>
    /// finds out if named object has script added to it already
    /// if it doesnt then it adds it
    /// if it does then it stops the function
    ///</AttachScript>
    public void AttachScripts()
    {
        myObject = GameObject.Find("MyObject");
        Transform parents = GetComponentInParent<Transform>();

        if (parentList == null)
        {
            parentList = new List<GameObject>();
        }

        foreach (Transform parent in parents)
        {
            parentList.Add(parent.gameObject);
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

        MeshRenderer renderer = GetComponentInParent<MeshRenderer>();

        if (renderer != null)
        {
            renderer.gameObject.AddComponent<OnePlaneCuttingConnectorVR>();
            renderer.gameObject.AddComponent<ChangeMaterial>();
            renderer.gameObject.AddComponent<QuadLocation>();
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