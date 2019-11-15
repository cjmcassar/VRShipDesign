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
    /// 

    public GameObject SixFoot;
    public GameObject SixFootClone;
    
    public GameObject LMCasual;
    public GameObject LMCasualClone;

    public GameObject LMCrouch;
    public GameObject LMCrouchClone;

    public GameObject LMSeated;
    public GameObject LMSeatedClone;

    public GameObject MMCasual;
    public GameObject MMCasualClone;

    public GameObject MMCrouch;
    public GameObject MMCrouchClone;

    public GameObject MMSeated;
    public GameObject MMSeatedClone;

    public GameObject SFCasual;
    public GameObject SFCasualClone;

    public GameObject SFCrouch;
    public GameObject SFCrouchClone;

    public GameObject SFSeated;
    public GameObject SFSeatedClone;


    public void UploadSF()
    {
        SixFoot = Resources.Load("Base Mesh sculpt 2", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(SixFoot);
        SixFootClone = GameObject.Find("INS(Clone)");

        controller = GameObject.Find("Controller (left)");
        SixFootClone.transform.position = controller.transform.position;
    }

    public void UploadLMCasual()
    {
        LMCasual = Resources.Load("LM-Casual", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(LMCasual);
        LMCasualClone = GameObject.Find("LM-Casual(Clone)");

        controller = GameObject.Find("Controller (left)");
        LMCasualClone.transform.position = controller.transform.position;
    }

    public void UploadLMCrouch()
    {
        LMCrouch = Resources.Load("LM-Crouch", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(LMCrouch);
        LMCrouchClone = GameObject.Find("LM-Crouch(Clone)");

        controller = GameObject.Find("Controller (left)");
        LMCrouchClone.transform.position = controller.transform.position;
    }

    public void UploadLMSeated()
    {
        LMSeated = Resources.Load("LM-Seated", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(LMSeated);
        LMSeatedClone = GameObject.Find("LM-Seated(Clone)");

        controller = GameObject.Find("Controller (left)");
        LMSeatedClone.transform.position = controller.transform.position;
    }

    public void UploadMMCasual()
    {
        MMCasual = Resources.Load("MM-Casual", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(MMCasual);
        MMCasualClone = GameObject.Find("MM-Casual(Clone)");

        controller = GameObject.Find("Controller (left)");
        MMCasualClone.transform.position = controller.transform.position;
    }

    public void UploadMMCrouch()
    {
        MMCrouch = Resources.Load("MM-Crouch", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(MMCrouch);
        MMCrouchClone = GameObject.Find("MM-Crouch(Clone)");

        controller = GameObject.Find("Controller (left)");
        MMCrouchClone.transform.position = controller.transform.position;
    }

    public void UploadMMSeated()
    {
        MMSeated = Resources.Load("MM-Seated", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(MMSeated);
        MMSeatedClone = GameObject.Find("MM-Seated(Clone)");

        controller = GameObject.Find("Controller (left)");
        MMSeatedClone.transform.position = controller.transform.position;
    }

    public void UploadSFCasual()
    {
        SFCasual = Resources.Load("SF-Casual", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(SFCasual);
        SFCasualClone = GameObject.Find("SF-Casual(Clone)");

        controller = GameObject.Find("Controller (left)");
        SFCasualClone.transform.position = controller.transform.position;
    }

    public void UploadSFCrouch()
    {
        SFCrouch = Resources.Load("SF-Crouch", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(SFCrouch);
        SFCrouchClone = GameObject.Find("SF-Crouch(Clone)");

        controller = GameObject.Find("Controller (left)");
        SFCrouchClone.transform.position = controller.transform.position;
    }

    public void UploadSFSeated()
    {
        SFSeated = Resources.Load("SF-Seated", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(SFSeated);
        MMSeatedClone = GameObject.Find("SF-Seated(Clone)");

        controller = GameObject.Find("Controller (left)");
        SFSeatedClone.transform.position = controller.transform.position;
    }



}
