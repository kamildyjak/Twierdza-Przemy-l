using UnityEngine;
using System.Collections;

public class TrackCamera : MonoBehaviour {

	// Use this for initialization

	GameObject camera;
	void Start () {
		camera = GameObject.Find("ARCamera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cam_rotation = camera.transform.localRotation.eulerAngles;
		Vector3 rotation = transform.localRotation.eulerAngles;
		transform.localEulerAngles = new Vector3 (rotation.x, cam_rotation.y, rotation.z);
	}
}
