using UnityEngine;
using System.Collections;
using Vuforia;

public class ScreenOrient : MonoBehaviour {

    public string Orientation;

	void Start() {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (Orientation == "Portrait")
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
		
	}

	void Update(){
        if (Orientation == "Portrait")
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}
