using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public SteamVR_TrackedObject trackedObj;

    // Update is called once per frame
    void Update ()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            ScreenshotHandler.TakeScreenshot_Static(500, 500);
        }
	}
}
