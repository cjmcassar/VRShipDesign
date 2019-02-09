using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachMaterial : MonoBehaviour
{
    public GameObject myObject;
    public GameObject plane;
    public Material PlaneCutter;


<<<<<<< HEAD



    // Update is called once per frame
    void Update()
=======
    // OnEnable is called once the object is initiated
    void OnEnable()
>>>>>>> 2d1c13256db2689b1a65989dde6068394e018f7d
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

<<<<<<< HEAD

        //TODO there is a bug that seems to be asscociated with the update method... Need to find a way to activate this method ONCE...

=======
>>>>>>> 2d1c13256db2689b1a65989dde6068394e018f7d
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
<<<<<<< HEAD


    }

   
=======
    }

>>>>>>> 2d1c13256db2689b1a65989dde6068394e018f7d

}








