using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLocation : MonoBehaviour {

    public GameObject quad;
    public GameObject quadClone;
    public Transform ObjectToHide;

    public GameObject controller;

    // Use this for initialization
    public void Start ()
    {
        LoadQuad();
        ChangeQuadLocation();
    }

    private void LoadQuad()
    {
        quad = Resources.Load("Quad", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(quad);
        quadClone = GameObject.Find("Quad(Clone)");
        ObjectToHide = this.transform;
        quadClone.transform.SetParent(ObjectToHide);
    }

    private void ChangeQuadLocation()
    {
        controller = GameObject.Find("Controller (left)");
        quadClone.transform.position = controller.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // TODO 1 needs to change the position of the quad to that of the controller
    // TODO 2 the quad could use the transform position of the controller.. 
    // TODO 3 the issue would be finding the controller. Maybe another gameobject.find would work .
}
