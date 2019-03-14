using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;
using VRTK;
using System;

public class RigidBodyScript : MonoBehaviour
{
    #region Old Code
    //public Rigidbody bodyRigidbody;
    //public Rigidbody customPlayAreaRigidbod;
    //public float bodyMass = 0f;
    //public Transform playArea;
    //public bool generateRigidbody = false;

    //GameObject myObject = GameObject.Find("MyObject");
    #endregion 

    public List<GameObject> childrenList = new List<GameObject>();

    public GameObject preFab;

    void Start()
    {
        Invoke("AddDecendants", 12);
    }


    /// <AddDecendants Description>
    /// Looks through childrenList for children with transforms
    /// These children are then referenced in the script
    /// The code then looks through the children with a meshrenderer
    /// Each object with a meshrenderer gets a mesh collider and rigid body
    /// </AddDecendants Description>
    private void AddDecendants()
    {
        childrenList.Clear();
        Transform[] children = GetComponentsInChildren<Transform>(true);


        GameObject preFab = Resources.Load("RadialMenuSD", typeof(GameObject)) as GameObject;


        if (childrenList == null)
        {
            childrenList = new List<GameObject>();
        }

        foreach (Transform child in children)
        {
            childrenList.Add(child.gameObject);
        }

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        Component interactableScript = GetComponent<VRTK_InteractableObject>();

        for (int i = 0; i < renderers.Length; i++)
        {
            MeshCollider meshCollider = renderers[i].GetComponent<MeshCollider>();
            #region Rigidbody 
            //Rigidbody rigidBody = renderers[i].GetComponent<Rigidbody>(); 
            #endregion


            if (meshCollider == null /*&& rigidBody == null*/)
            {
                meshCollider = renderers[i].gameObject.AddComponent<MeshCollider>();
                meshCollider.convex = false;
                #region RigidBody
                //rigidBody = renderers[i].gameObject.AddComponent<Rigidbody>();
                //rigidBody.useGravity = false;
                //rigidBody.isKinematic = true;
                #endregion
                interactableScript = renderers[i].gameObject.AddComponent<VRTK_InteractableObject>();

                GameObject radialmenu = GameObject.Instantiate(preFab);
                radialmenu.transform.SetParent(renderers[i].transform);
            }

            else if (meshCollider != null)
            {
                break;
            }

        }
        // TODO - Needs to add the rigid body to the parent object (richard's advice..Will test).

    }

    #region Old Code
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
    #endregion
}



#region Old Code
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
////    }
#endregion