using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLocation : MonoBehaviour {

    public GameObject quad;
    public GameObject quadClone;
    public Transform ObjectToHide;

	// Use this for initialization
	public void Start ()
    {
        LoadQuad();

    }

    private void LoadQuad()
    {
        quad = Resources.Load("Quad", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(quad);
        quadClone = GameObject.Find("Quad(Clone)");
        ObjectToHide = this.transform;
        quadClone.transform.SetParent(ObjectToHide);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void ChangeQuadLocation()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

            if (renderer == null )
            {

            }

            else if (renderer != null)
            {

            }

    }

    // TODO 1 needs to change the position of the quad to that of the controller
    // TODO 2 the quad could use the transform position of the controller.. 
    // TODO 3 the issue would be finding the controller. Maybe another gameobject.find would work .
}
