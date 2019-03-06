﻿using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingControllerVR : MonoBehaviour
{

    public GameObject plane;
    private GameObject myObject;
    Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;
        UpdateShaderProperties();
        plane = GameObject.Find("Quad"); // finds the plane object in the scene and attaches it to the script
    }
    void Update()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {
        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;
        rend.material.SetVector("_PlaneNormal", normal);
        rend.material.SetVector("_PlanePosition", position);
    }

    // TODO needs to change the position of the quad to that of the controller

}
