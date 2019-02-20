using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyScript : MonoBehaviour
{

    public Rigidbody bodyRigidbody;
    public Rigidbody customPlayAreaRigidbody = null;
    public float bodyMass = 100f;
    public Transform playArea;
    public bool generateRigidbody = false;


    public List<GameObject> childrenList = new List<GameObject>();



    void Start()
    {
        Invoke("AddDecendants", 15);
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

        for (int i = 0; i < childrenList.Count; i++)
        {
            Mesh mesh = childrenList[i].GetComponent<Mesh>();
            MeshCollider mc = childrenList[i].GetComponent<MeshCollider>();
            if (mesh == null)
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