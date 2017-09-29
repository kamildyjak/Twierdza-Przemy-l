using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroCanvasScript : MonoBehaviour {

	public GameObject TopRegion;
	public GameObject SceneManager;
	public GameObject Dots;
    public string scaneName;
	LoadAsyncScene script;
	Image pageDots;
	Animator canvasAnimator;
	private int index = 0;

	void Start () {
		script = SceneManager.GetComponent<LoadAsyncScene>();
		if(TopRegion != null)
			canvasAnimator = TopRegion.GetComponent<Animator> ();
		EnableLevel ("Scan", false);
		EnableLevel ("Next", false);
		EnableLevel ("Explore", false);
		EnableLevel ("Start", false);
		EnableLevel ("Loading", false);
		EnableLevel ("Canvas_kartka", true);
		if (Dots != null) {
			pageDots = Dots.GetComponent<Image> ();
			pageDots.enabled = false;
		}
	}
		

	public void Skip(string scene_name){
		EnableLevel ("Welcome", false);
		EnableLevel ("Loading", true);
		canvasAnimator.Play ("Intro_loading");
		//PlayerPrefs.SetInt ("FirstStart", 1);
		StartCoroutine (script.LoadNextSceneAfter (0, scene_name));
	}

	public void EnableLevel(string levelName, bool value){
		GameObject level = GameObject.Find (levelName);
		if (level != null) {
			Button[] buttons = level.GetComponentsInChildren<Button> ();
			Text[] texts = level.GetComponentsInChildren<Text> ();
			Image[] images = level.GetComponentsInChildren<Image> ();

			foreach (Button component in buttons)
				component.enabled = value;

			foreach (Text component in texts)
				component.enabled = value;

			foreach (Image component in images)
				component.enabled = value;
		}
	}

	public void SlideControl(bool left){
		if (left == true) {
			switch (index) {
			case 0:
				Tutorial_start ();
				break;
			case 1:
				Tutorial_explore ();
				break;
			case 2:
				Start (scaneName);
				break;
			}
		} else {
			switch (index) {
			case 2:
				Tutorial_explore_back ();
				index--;
				break;
			}
		}
	}
		
	public void Tutorial_start(){
		index++;
		EnableLevel("Skip", false);
		EnableLevel("Tutorial", false);
		EnableLevel("Scan", true);
		EnableLevel ("Next", true);
		pageDots.enabled = true;
		//canvasAnimator.enabled = true;
		canvasAnimator.Play ("Intro_scan");
	}
		
	public void Tutorial_explore(){
		index++;
		EnableLevel ("Next", false);
		EnableLevel ("Explore", true);
		EnableLevel ("Start", true);
		pageDots.transform.localEulerAngles = new Vector3 (0f, 0f, -180f);
		canvasAnimator.Play ("Intro_explore");
	}

	public void Tutorial_explore_back(){
		EnableLevel ("Next", true);
		EnableLevel ("Explore", true);
		EnableLevel ("Start", false);
		pageDots.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
		canvasAnimator.Play ("Intro_explore_back");
	}

	public void Start(string scene_name){
		EnableLevel ("Scan", false);
		EnableLevel ("Next", false);
		EnableLevel ("Explore", false);
		EnableLevel ("Welcome", false);
		EnableLevel ("Loading", true);
		canvasAnimator.Play ("Intro_loading");
		//PlayerPrefs.SetInt ("FirstStart", 1);
		StartCoroutine (script.LoadNextSceneAfter (0, scene_name));
	}
		
	public void Domek(){
		GameObject.Find ("Canvas_detect").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Text_detect").GetComponent<Text> ().text = "Wczytywanie modeli...";
		GameObject.Find ("Canvas_detect").GetComponent<Animator> ().enabled = true;
		GameObject.Find ("Canvas_detect").GetComponent<Animator> ().Play ("Loading");
		StartCoroutine(script.LoadNextSceneAfter (0, "Domek"));
	}
}
