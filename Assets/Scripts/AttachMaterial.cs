using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachMaterial : MonoBehaviour
{
    public GameObject childObject;
    public GameObject plane = Resources.Load("Quad", typeof(GameObject)) as GameObject;
    public Material PlaneCutter;


    // OnEnable is called once the object is initiated
    void OnEnable()
    {
        AttachPlaneCutter();
    }

    // AttachPlaneCutter Description
    // Finds the games objects and materials then attaches is to the named object
    private void AttachPlaneCutter()
    {
        childObject = GetComponent<GameObject>();                                                   // references the gameobject that this script is attached to (hopefully)

        MeshRenderer renderer = GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                PlaneCutter = Resources.Load("OnePlaneCrossSection", typeof(Material)) as Material;  // finds the material in the resources folder and attaches it to the script
                childObject.GetComponent<Renderer>().sharedMaterial = PlaneCutter;                   // Gets the material and attaches it to the obejct
                GameObject quad = GameObject.Instantiate(plane);                                     // instantiates the quad
            }
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
