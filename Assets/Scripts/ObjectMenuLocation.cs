using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuLocation : MonoBehaviour {

    public GameObject headSet;
    public float distanceFromheadSet;

    private void Start()
    {
        headSet = GameObject.Find("MenuCollider");
    }

    // Update is called once per frame
    void Update ()  
    {
        MenuMovement();
    }


    private void MenuMovement()
    {
        transform.position = headSet.transform.position + (headSet.transform.forward * distanceFromheadSet);
    }

}
