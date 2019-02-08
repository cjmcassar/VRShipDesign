using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachMaterial : MonoBehaviour
{
    public GameObject myObject;
    public GameObject plane;
    public Material PlaneCutter;


    // OnEnable is called once the object is initiated
    void OnEnable()
    {
        AttachPlaneCutter();
    }

    // AttachPlaneCutter Description
    // Finds the games objects and materials then attaches is to the named object
    // TODO figure out how to attach it the object that is in the scene
    private void AttachPlaneCutter()
    {

        myObject = GameObject.Find("MyObject/Layer_0/Layer_0");
        plane = GameObject.Find("Quad");                                                            // finds the plane object in the scene and attaches it to the script
        PlaneCutter = Resources.Load("OnePlaneCrossSection", typeof(Material)) as Material;         // finds the material in the resources folder and attaches it to the script
        myObject.GetComponentInChildren<Renderer>().sharedMaterial = PlaneCutter;                   // Gets the material and attaches it to the obejct

        #region OldCode
        //if (myObject.name == "Layer_0" /*&& myObject.GetComponent<OnePlaneCuttingControllerVR>()*/)
        //{

        //    // TODO get the material from the plane
        //}
        //else if (myObject.name != "Layer_0" /*&& !myObject.GetComponent<OnePlaneCuttingControllerVR>()*/)
        //{
        //    return;
        //}
        #endregion
    }


}
