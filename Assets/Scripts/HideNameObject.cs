using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNameObject : MonoBehaviour {

    public GameObject menuNameObject;
    public GameObject equipmentObject;

    //public Transform target;

    public new SphereCollider collider;


    private void Update()
    {
        HideMenuName();
    }

    //Hides name when menu is hidden

    public void HideMenuName()
    {
        equipmentObject = menuNameObject.transform.parent.parent.gameObject;
        collider = equipmentObject.GetComponent<SphereCollider>();

        if (!collider.enabled)
        {
            menuNameObject.SetActive(false);
        }

        else if (collider.enabled)
        {
            menuNameObject.SetActive(true);
        }
    }

}

