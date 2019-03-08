using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectFunction : MonoBehaviour {

    public GameObject quadClone;

    public GameObject myObject;
    public List<GameObject> parentList = new List<GameObject>();

    


    public void ResetFunctions()
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

        Component OnePlane = GetComponentInParent<OnePlaneCuttingConnectorVR>();
        Component changeMaterial = GetComponentInParent<ChangeMaterial>();
        Component quadLocation = GetComponentInParent<QuadLocation>();

        if (OnePlane != null && changeMaterial != null && quadLocation != null)
        {
            Destroy(OnePlane.gameObject.AddComponent<OnePlaneCuttingConnectorVR>());
            Destroy(changeMaterial.gameObject.AddComponent<ChangeMaterial>());
            Destroy(quadLocation.gameObject.AddComponent<QuadLocation>());

            quadClone = GameObject.Find("Quad(Clone)");
            Destroy(quadClone);
        }

    }


}
