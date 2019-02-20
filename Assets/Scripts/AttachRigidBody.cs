using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachRigidBody : MonoBehaviour {

    private Rigidbody bodyRigidbody;
    public Rigidbody customPlayAreaRigidbody = null;
    public float bodyMass = 100f;
    public Transform playArea;
    protected bool generateRigidbody = false;

 //   // Use this for initialization
 //   void Start () {
		
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}


    private void AddRigidBody()
    {
        if (customPlayAreaRigidbody != null)
        {
            HasExistingRigidbody();
            bodyRigidbody.mass = customPlayAreaRigidbody.mass;
            bodyRigidbody.drag = customPlayAreaRigidbody.drag;
            bodyRigidbody.angularDrag = customPlayAreaRigidbody.angularDrag;
            bodyRigidbody.useGravity = customPlayAreaRigidbody.useGravity;
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

    protected virtual bool HasExistingRigidbody()
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
