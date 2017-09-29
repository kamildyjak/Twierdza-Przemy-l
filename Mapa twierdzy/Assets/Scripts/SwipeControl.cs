using UnityEngine;
using System.Collections;

public class SwipeControl : MonoBehaviour {

	private Touch initialTouch = new Touch ();
	private float distance = 0;
	private bool hasSwiped = false;
	private float minDistance = 0;

	private IntroCanvasScript script;

	void Start(){
		script = GetComponent<IntroCanvasScript> ();
	}

	void Update(){
		minDistance = Screen.width * 0.15f;
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				initialTouch = new Touch();
				initialTouch = t;
			} else if (t.phase == TouchPhase.Moved && !hasSwiped) {
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = initialTouch.position.y - t.position.y;
				distance = Vector2.Distance (initialTouch.position, t.position);

				bool swipedSideways = Mathf.Abs (deltaX) > Mathf.Abs (deltaY);

				if (distance > minDistance) {
					if (swipedSideways && deltaX > 0) { // swipe left
						Debug.Log("Left");
						script.SlideControl (true);
					} else if (swipedSideways && deltaX <= 0) { // swipe right
						Debug.Log("Right");
						script.SlideControl (false);
					} else if (!swipedSideways && deltaY > 0) { // swiped down
						Debug.Log("Down");
					} else if (!swipedSideways && deltaY <= 0) { // swiped up
						Debug.Log("Up");
					}

					hasSwiped = true;
				}

			} else if (t.phase == TouchPhase.Ended) {
				initialTouch = new Touch();
				hasSwiped = false;
			}

		}

	}

}
