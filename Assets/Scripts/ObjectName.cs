using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectName : MonoBehaviour 

{
    public Transform target;
    private string textToDisplay;

    public bool displayName = true;
    public bool displayTAG = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nameDisplayer();
        tagDisplayer();
    }

    void LateUpdate()
    {
        //Make the text allways face the camera
        transform.rotation = Camera.main.transform.rotation;
    }

    //displays the name of the parent
    void nameDisplayer()
    {


        if (displayName)
        {
            displayTAG = false;
            textToDisplay = GetComponent<TextMesh>().text; /*(string)this.transform.parent.name;*/
            //changes the text to the Name
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
            textToDisplay = (string)this.transform.parent.tag;
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


