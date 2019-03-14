using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectFunction : MonoBehaviour {


    public GameObject quadClone;
    public GameObject myObject;
    public List<GameObject> parentList = new List<GameObject>();

    public Transform Parent;

    public Material material;


    public Component OnePlane;
    public Component changeMaterial;
    public Component quadLocation;

    /// <Start Summary>
    /// Initialises the functions that are necessary right at the beginning.
    /// </Start Summary>
    public void Start()
    {
        myObject = this.gameObject;
        Parent = GetComponentInParent<Transform>();
    }


    /// <ResetFunction Summary>
    /// Finds the gameobject, then the quad
    /// Then an if statement is initialised in which takes into account the necessary conditions
    /// This then removes the scripts initially put there by the previous functions
    /// </ResetFunction Summary>
    public void ResetFunctions()
    {
        myObject = GameObject.Find("MyObject");
        quadClone = GameObject.Find("Quad(Clone)");

        OnePlane = this.gameObject.GetComponentInParent<OnePlaneCuttingConnectorVR>();
        changeMaterial = this.gameObject.GetComponentInParent<ChangeMaterial>();
        quadLocation = this.gameObject.GetComponentInParent<QuadLocation>();

        if (OnePlane != null && changeMaterial != null && quadLocation != null)
        {
            Destroy(this.gameObject.GetComponentInParent<OnePlaneCuttingConnectorVR>());
            Destroy(this.gameObject.GetComponentInParent<ChangeMaterial>());
            Destroy(this.gameObject.GetComponentInParent<QuadLocation>());

            Destroy(quadClone);
        }

        ChangeObjectColour();

    }

    /// <ChangeObjectColour Summary>
    /// This looks for the parent object then changes the colour
    /// </ChangeObjectColour Summary>
    public void ChangeObjectColour()
    {
        foreach (Transform parent in Parent)
        {
            parentList.Add(parent.gameObject);
            material = Resources.Load("glass", typeof(Material)) as Material;
            Parent.transform.GetComponentInParent<Renderer>().sharedMaterial = material;
        }

    }


}
