using UnityEngine;
using System.Collections;

public class Scaling : MonoBehaviour {
	
	Vector2 last_0_position, last_1_position, last_drag_position;
	int tak;
	private Vector3 velocity = Vector3.zero;
	GameObject mapa;
	float time_delay, timeSinceStarted, delta;
	float speed = 1;
	private Vector3 lastPlanePoint;
	Vector3 stop;

	void Start () {
		tak = 0;
		mapa = GameObject.Find("Zawartosc");
		time_delay = 0;
		//stop = new Vector3(-13.3f, 13.1f, -9.1f);
		stop = Vector3.zero;
	}
	

	void Update () {
		GameObject top_p = GameObject.Find ("Top");
		GameObject bottom_p = GameObject.Find ("Bottom");
		GameObject left_p = GameObject.Find ("Left");
		GameObject right_p = GameObject.Find ("Right");
		
		//Debug.Log ("T-z: "+top_p.transform.position.z+", B-z: "+bottom_p.transform.position.z+", L-x: "+left_p.transform.position.x+", P-x: "+right_p.transform.position.x);
		
		if (Input.touchCount == 2) {
			if(Input.GetTouch(1).phase == TouchPhase.Began){
				last_0_position = Input.GetTouch(0).position;
				last_1_position = Input.GetTouch(1).position;
				timeSinceStarted = Time.time;
			}else{
				float last_distance = Vector3.Distance(last_0_position ,last_1_position);
				float distance = Vector3.Distance(Input.GetTouch(0).position ,Input.GetTouch(1).position);
				float distance_delta = distance - last_distance;
				Debug.Log (distance_delta);
				last_0_position = Input.GetTouch(0).position;
				last_1_position = Input.GetTouch(1).position;
				distance_delta = distance_delta / 50000;
				Vector3 new_scale;
				new_scale = new Vector3(mapa.transform.localScale.x + distance_delta, mapa.transform.localScale.y + distance_delta, mapa.transform.localScale.z + distance_delta);
				if(new_scale.x >= 0.0028 && new_scale.x <= 0.02){
					if(new_scale.x < mapa.transform.localScale.x){
						delta = mapa.transform.localScale.x - new_scale.x;
						float fraction = 1 - (delta / (mapa.transform.localScale.x - 0.0028f));
						mapa.transform.position = new Vector3(mapa.transform.position.x * fraction, 0 ,mapa.transform.position.z * fraction); 
					}

					mapa.transform.localScale = new_scale;
					time_delay = Time.time + 0.5f;
				}
			}
			
		}
		if (Input.touchCount == 1) {
			Plane targetPlane = new Plane(transform.up, transform.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			float dist = 0.0f;
			targetPlane.Raycast(ray, out dist);
			Vector3 planePoint = ray.GetPoint(dist);
			if(Input.GetTouch(0).phase == TouchPhase.Began){
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit)){
					lastPlanePoint = planePoint;
					tak = 1;
				}else
					tak = 0;
			}
			
			
			if(Input.GetTouch(0).phase == TouchPhase.Moved && tak == 1 && Time.time > time_delay){
			
				Vector3 pos_tmp = mapa.transform.position;
				Vector3 new_pos = planePoint - lastPlanePoint;
				new_pos.y = 0; 
				mapa.transform.position += new_pos;
				lastPlanePoint = planePoint;
				if(top_p.transform.position.z  < 95.2f || bottom_p.transform.position.z > -96.8f || left_p.transform.position.x > -136.4f || right_p.transform.position.x  < 133.2f)
					mapa.transform.position = pos_tmp;
			}
			
		}
		
	}
}
