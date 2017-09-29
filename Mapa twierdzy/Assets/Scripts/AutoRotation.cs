using UnityEngine;
using System.Collections;

public class AutoRotation : MonoBehaviour {

	void Update () {





		var AR_cam = GameObject.Find("ARCamera");
		Vector3 rotation = AR_cam.transform.rotation.eulerAngles;
		Renderer[] renderComponents = gameObject.GetComponentsInChildren<Renderer> ();
		var x = rotation.x;
		if (x > 80)
			x = 80;
        foreach (Renderer component in renderComponents)
        {
            if (component.name.Equals("Napisy"))
                component.transform.rotation = Quaternion.Euler(x, rotation.y, 0);

            if (component.name.Equals("Kruhel"))
                component.transform.rotation = Quaternion.Euler(-x, rotation.y - 180, 0);

        }
	}
}
