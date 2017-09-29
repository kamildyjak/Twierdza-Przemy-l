using UnityEngine;
using System.Collections;

public class MenuScripts : MonoBehaviour {

	GameObject camera;
	GameObject menu;
	float distance;
	float distance_1;
	void Start () {
		camera = GameObject.Find("ARCamera");
		menu = GameObject.Find ("Menu");
		Vector3 cam_pos = camera.transform.localPosition;
		Vector3 menu_pos = menu.transform.localPosition;
		distance = Vector3.Distance (menu_pos, cam_pos);
	}

	// Update is called once per frame
	void Update () {
		Vector3 cam_pos = camera.transform.localPosition;
		Vector3 menu_pos = menu.transform.localPosition;
        //distance_1 = Vector3.Distance (menu_pos, cam_pos);
        //float move = (distance_1 - distance) / 10;
        float y = menu.transform.localPosition.y;
        if (cam_pos.z > 0) {
            menu.transform.localPosition = new Vector3 (0.05f, y, 0.7403f);
		} else {
			menu.transform.localPosition = new Vector3 (0.05f, y, 0.050f);
		}
	}
}
