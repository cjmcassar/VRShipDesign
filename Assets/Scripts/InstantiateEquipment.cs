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
    public GameObject INS;
    public GameObject INSClone;
    public void UploadINS()
    {
        INS = Resources.Load("NameOfEquipmentorAvatar", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(INS);
        INSClone = GameObject.Find("INS(Clone)");

        controller = GameObject.Find("Controller (left)");
        INSClone.transform.position = controller.transform.position;
    }
}
