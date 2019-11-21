using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEquipment : MonoBehaviour {

    public GameObject controller;
    public Transform ObjectToHide;

/// <Upload Equipment summary>
/// This uploads the equipment objects from the resources folder.
/// This code is essentially repeated for each equipment slot.
/// </ Upload Equipment summary>
/// 
    public GameObject INS;
    public GameObject INSClone;

    public GameObject Stairwell;
    public GameObject StairwellClone;

    public GameObject Chair;
    public GameObject ChairClone;

    public GameObject Toolbox;
    public GameObject ToolboxClone;

    public GameObject Engine;
    public GameObject EngineClone;



    public void UploadINS()
    {
        INS = Resources.Load("INS", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(INS);
        INSClone = GameObject.Find("INS(Clone)");

        controller = GameObject.Find("Controller (left)");
        INSClone.transform.position = controller.transform.position;
    }

    public void UploadStairwell()
    {
        Stairwell = Resources.Load("Stairwell", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(Stairwell);
        StairwellClone = GameObject.Find("Stairwell(Clone)");

        controller = GameObject.Find("Controller (left)");
        StairwellClone.transform.position = controller.transform.position;
    }

    public void UploadChair()
    {
        Chair = Resources.Load("Chair", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(Chair);
        ChairClone = GameObject.Find("Chair(Clone)");

        controller = GameObject.Find("Controller (left)");
        ChairClone.transform.position = controller.transform.position;
    }

    public void UploadToolBox()
    {
        Toolbox = Resources.Load("Toolbox", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(Toolbox);
        ToolboxClone = GameObject.Find("Toolbox(Clone)");

        controller = GameObject.Find("Controller (left)");
        ToolboxClone.transform.position = controller.transform.position;
    }

    public void UploadEngine()
    {
        Engine = Resources.Load("Engine", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(Engine);
        EngineClone = GameObject.Find("Engine(Clone)");

        controller = GameObject.Find("Controller (left)");
        EngineClone.transform.position = controller.transform.position;
    }
}
