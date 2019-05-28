using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAvatars : MonoBehaviour {

    public GameObject controller;
    public Transform ObjectToHide;

    /// <Upload Avatar summary>
    /// This uploads the avatar dummy objects from the resources folder.
    /// This code is essentially repeated for each avatar dummy slot.
    /// </ Upload Avatar summary>
    public GameObject SixFoot;
    public GameObject SixFootClone;
    public void UploadSF()
    {
        SixFoot = Resources.Load("Base Mesh sculpt 2", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(SixFoot);
        SixFootClone = GameObject.Find("INS(Clone)");

        controller = GameObject.Find("Controller (left)");
        SixFootClone.transform.position = controller.transform.position;
    }
}
