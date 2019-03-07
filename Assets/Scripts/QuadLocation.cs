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

    /// <QuadLocation Description>
    /// Locates the quad prefab in the resources folder then clones it into the game environment
    /// </QuadLocation Description>
    private void LoadQuad()
    {
        quad = Resources.Load("Quad", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(quad);
        quadClone = GameObject.Find("Quad(Clone)");
        ObjectToHide = this.transform;
        quadClone.transform.SetParent(ObjectToHide);
    }

    /// <ChangeQuadLocation Description>
    /// Locates the controller prefab and sends the quad to that location
    /// </ChangeQuadLocation Description>
    private void ChangeQuadLocation()
    {
        controller = GameObject.Find("Controller (left)");
        quadClone.transform.position = controller.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
