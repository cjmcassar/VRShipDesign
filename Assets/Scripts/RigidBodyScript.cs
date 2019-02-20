using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyScript : MonoBehaviour
{

    //public Rigidbody bodyRigidbody;
    //public Rigidbody customPlayAreaRigidbod;
    //public float bodyMass = 0f;
    //public Transform playArea;
    //public bool generateRigidbody = false;


    public List<GameObject> childrenList = new List<GameObject>();



    void Start()
    {
        Invoke("AddDecendants", 10);
    }

    private void AddDecendants()
    {
        childrenList.Clear();
        Transform[] children = GetComponentsInChildren<Transform>(true);

        if (childrenList == null)
        {
            childrenList = new List<GameObject>();
        }

        foreach (Transform child in children)
        {
            childrenList.Add(child.gameObject);
        }

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            MeshCollider meshCollider = renderers[i].GetComponent<MeshCollider>();

            if (meshCollider == null)
            {
                meshCollider = renderers[i].gameObject.AddComponent<MeshCollider>();
                meshCollider.convex = false;
            }
        

            else if (meshCollider != null)
            {
                break;
            }
           
        }
        // TODO - Needs to add the rigid body to the parent object (richard's advice..Will test).




    }

    //private void AddRigidBody()
    //{
    //    if (customPlayAreaRigidbody != null)
    //    {
    //        HasExistingRigidbody();
    //        bodyRigidbody.mass = customPlayAreaRigidbody.mass;
    //        bodyRigidbody.drag = customPlayAreaRigidbody.drag;
    //        bodyRigidbody.angularDrag = customPlayAreaRigidbody.angularDrag;
    //        bodyRigidbody.useGravity = !customPlayAreaRigidbody.useGravity;
    //        bodyRigidbody.isKinematic = customPlayAreaRigidbody.isKinematic;
    //        bodyRigidbody.interpolation = customPlayAreaRigidbody.interpolation;
    //        bodyRigidbody.collisionDetectionMode = customPlayAreaRigidbody.collisionDetectionMode;
    //        bodyRigidbody.constraints = customPlayAreaRigidbody.constraints;
    //    }
    //    else
    //    {
    //        if (!HasExistingRigidbody())
    //        {
    //            bodyRigidbody.mass = bodyMass;
    //            bodyRigidbody.freezeRotation = true;
    //        }
    //    }
    //}

    //private bool HasExistingRigidbody()
    //{
    //    Rigidbody existingRigidbody = playArea.GetComponent<Rigidbody>();
    //    if (existingRigidbody != null)
    //    {
    //        generateRigidbody = false;
    //        bodyRigidbody = existingRigidbody;
    //        return true;
    //    }
    //    else
    //    {
    //        generateRigidbody = true;
    //        bodyRigidbody = playArea.gameObject.AddComponent<Rigidbody>();
    //        return false;
    //    }
    //}
}




//for (int i = 0; i < childrenList.Count; i++)
//{
//    Mesh mesh = childrenList[i].GetComponent<Mesh>();
//    MeshCollider mc = childrenList[i].GetComponent<MeshCollider>();
//    Rigidbody rb = childrenList[i].GetComponent<Rigidbody>();
//    if (mesh == null && mc == null && rb == null)
//    {
//        //mesh = childrenList[i].AddComponent<MeshRenderer>();
//        //mc = childrenList[i].AddComponent<MeshCollider>();
//        //mc.convex = true;
//        rb = childrenList[i].AddComponent<Rigidbody>();
//        rb.useGravity = false;
//        rb.isKinematic = true;
//    }
