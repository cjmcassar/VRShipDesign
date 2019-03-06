using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadLocation : MonoBehaviour {

    public GameObject quad;

	// Use this for initialization
	public void Start ()
    {
        quad = Resources.Load("Quad", typeof(GameObject)) as GameObject;
        GameObject.Instantiate(quad);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void GetQuad()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

            if (renderer == null )
            {

                //radialmenu.transform.SetParent(renderer[i].transform);
            }

            else if (renderer != null)
            {

            }

    }

    // TODO needs to change the position of the quad to that of the controller
}
