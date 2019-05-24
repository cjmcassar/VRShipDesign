using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ObjectName : MonoBehaviour 
{

    //public Transform target;

    private string textToDisplay;
    

    public bool displayName = true;
    public bool displayTAG = false;
   

    // Use this for initialization
    void Start()
    {
        nameDisplayer();
        tagDisplayer();
    }

    void LateUpdate()
    {
        //Make the text allways face the camera
        //transform.rotation = Camera.main.transform.rotation;
    }

    //displays the name of the parent
    void nameDisplayer()
    {
        if (displayName)
        {
            displayTAG = false;
            textToDisplay = (string)this.transform.parent.parent.name + " Object Menu"; //changes the text to the Name

            changeTextColor(); 
        }
    }

    //displays the TAG of the parent
    void tagDisplayer()
    {
        if (displayTAG)
        {
            displayName = false;
            //changes the text to the TAG
            textToDisplay = (string)this.transform.parent.parent.tag;
            changeTextColor();
        }
    }

    //Changes the color
    public void changeTextColor()
    {
        TextMesh tm = GetComponent<TextMesh>();
        tm.text = textToDisplay;
    }
}


