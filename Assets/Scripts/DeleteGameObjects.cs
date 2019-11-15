using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObjects : MonoBehaviour {

    public GameObject dhmAverage;

    public GameObject deleteGameObject;

    public void ToggleMenuOn()
    {
        deleteGameObject.SetActive(true);
    }
    public void ToggleMenuOff()
    {
        deleteGameObject.SetActive(false);
    }


    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject == dhmAverage)
        {
            Debug.Log("Collision");
            //Destroy(col.gameObject);
        }
	}
}
