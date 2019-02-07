using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachMaterial : MonoBehaviour
{
    public GameObject myObject;
    public GameObject plane;
    public Material PlaneCutter;





    // Update is called once per frame
    void Update()
    {
        AttachPlaneCutter();
        
    }


    //Figure out a way to attach the material to the object

    private void AttachPlaneCutter()
    {

        myObject = GameObject.Find("MyObject/Layer_0/Layer_0");
        plane = GameObject.Find("Quad");                                                            // finds the plane object in the scene and attaches it to the script
        PlaneCutter = Resources.Load("OnePlaneCrossSection", typeof(Material)) as Material;         // finds the material in the resources folder and attaches it to the script
        myObject.GetComponentInChildren<Renderer>().sharedMaterial = PlaneCutter;                   // Gets the material and attaches it to the obejct


        //TODO there is a bug that seems to be asscociated with the update method... Need to find a way to activate this method ONCE...

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








