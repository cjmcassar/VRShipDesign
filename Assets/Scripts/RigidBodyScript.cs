using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyScript : MonoBehaviour {

    public Rigidbody bodyRigidbody;
    public Rigidbody customPlayAreaRigidbody = null;
    public float bodyMass = 100f;
    public Transform playArea;
    public bool generateRigidbody = false;


    public List<GameObject> childrenList = new List<GameObject>();
   


    void Start()
    {
        Invoke ("AddDecendants", 15);
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
            //// First we get the Mesh attached to the child object
            //Mesh mesh = childrenList.gameObject.GetComponent<MeshFilter>().mesh;

            //// If we've found a mesh we can use it to add a collider
            //if (mesh != null)
            //{
            //    // Add a new MeshCollider to the child object
            //    MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();

            //    // Finaly we set the Mesh in the MeshCollider
            //    meshCollider.sharedMesh = mesh;
            //}
        }


        //for (int i = 0; i < children.Length; i++)
        //{
        //    Transform child = children[i];
        //    if (child != transform)
        //    {
        //        childrenList.Add(child.gameObject);
        //    }
        //}
        //go thorugh the list and add the component.


        //    // Iterate through all child objects of our Geometry object
        //    foreach (Transform childObject in transform)
        //    {
        //        // First we get the Mesh attached to the child object
        //        Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;

        //        // If we've found a mesh we can use it to add a collider
        //        if (mesh != null)
        //        {
        //            // Add a new MeshCollider to the child object
        //            MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();

        //            // Finaly we set the Mesh in the MeshCollider
        //            meshCollider.sharedMesh = mesh;
        //        }
        //    }



    



        for (int i = 0; i < childrenList.Count; i++)
        {
            Mesh mesh = childrenList[i].GetComponent<Mesh>();
            MeshCollider mc = childrenList[i].GetComponent<MeshCollider>();
            if ( mesh == null)
            {
                //mesh = childrenList[i].AddComponent<MeshRenderer>();
                mc = childrenList[i].AddComponent<MeshCollider>();
            }

            else if (mesh != null && mc != null)
            {
                break;
            }

            //AddRigidBody();
        }

        // TODO - Needs to add the rigid body to each child.
        // Tips:
        // a) use Start method;
        // b) use a Invoke or Coroutine with a timer;
        // c) add an flag inside the update loop to prevent it from running more than once;

    }

    private void AddRigidBody()
    {
        if (customPlayAreaRigidbody != null)
        {
            HasExistingRigidbody();
            bodyRigidbody.mass = customPlayAreaRigidbody.mass;
            bodyRigidbody.drag = customPlayAreaRigidbody.drag;
            bodyRigidbody.angularDrag = customPlayAreaRigidbody.angularDrag;
            bodyRigidbody.useGravity = !customPlayAreaRigidbody.useGravity;
            bodyRigidbody.isKinematic = customPlayAreaRigidbody.isKinematic;
            bodyRigidbody.interpolation = customPlayAreaRigidbody.interpolation;
            bodyRigidbody.collisionDetectionMode = customPlayAreaRigidbody.collisionDetectionMode;
            bodyRigidbody.constraints = customPlayAreaRigidbody.constraints;
        }
        else
        {
            if (!HasExistingRigidbody())
            {
                bodyRigidbody.mass = bodyMass;
                bodyRigidbody.freezeRotation = true;
            }
        }
    }

    private bool HasExistingRigidbody()
    {
        Rigidbody existingRigidbody = playArea.GetComponent<Rigidbody>();
        if (existingRigidbody != null)
        {
            generateRigidbody = false;
            bodyRigidbody = existingRigidbody;
            return true;
        }
        else
        {
            generateRigidbody = true;
            bodyRigidbody = playArea.gameObject.AddComponent<Rigidbody>();
            return false;
        }
    }
}
