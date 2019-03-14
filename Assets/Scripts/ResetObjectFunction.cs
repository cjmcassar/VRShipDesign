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


    public void Start()
    {
        quadClone = GameObject.Find("Quad(Clone)");
        myObject = this.gameObject;

        Parent = GetComponentInParent<Transform>();
    
        OnePlane = this.gameObject.GetComponentInParent<OnePlaneCuttingConnectorVR>();
        changeMaterial = this.gameObject.GetComponentInParent<ChangeMaterial>();
        quadLocation = this.gameObject.GetComponentInParent<QuadLocation>();

        ResetFunctions();
    }



    public void ResetFunctions()
    {
        myObject = GameObject.Find("MyObject");
 
        foreach (Transform parent in Parent)
        {
            parentList.Add(parent.gameObject);
        }

        if (OnePlane != null && changeMaterial != null && quadLocation != null)
        {
            Destroy(this.gameObject.GetComponentInParent<OnePlaneCuttingConnectorVR>());
            Destroy(this.gameObject.GetComponentInParent<ChangeMaterial>());
            Destroy(this.gameObject.GetComponentInParent<QuadLocation>());

            Destroy(quadClone);

            material = Resources.Load("glass", typeof(Material)) as Material;

            Parent.transform.GetComponent<Renderer>().sharedMaterial = material;

        }

    }


}
