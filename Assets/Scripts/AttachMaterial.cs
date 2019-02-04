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
        myObject = GameObject.Find("Layer_0");
        plane = GameObject.Find("Quad"); // finds the plane object in the scene and attaches it to the script
        if (myObject.name == "Layer_0" && myObject.GetComponent<OnePlaneCuttingControllerVR>())
        {
            ////Resources.Load("Materials/OnePlaneCrossSection", typeof(Material)) as Material;
            //myObject.GetComponent<Renderer>().material = PlaneCutter;                               // TODO get the material from the plane
        }
        else if (myObject.name != "Layer_0" && !myObject.GetComponent<OnePlaneCuttingControllerVR>())
        {
            return;
        }
    }

}
