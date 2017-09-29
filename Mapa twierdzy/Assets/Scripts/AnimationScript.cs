using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

    public Canvas menuCanvas;
    public GameObject firstLevel;
    public GameObject arCamera;

    private bool start;

    // Use this for initialization
    void Start () {
        start = false;
    }

    // Update is called once per frame
    void Update() {
       
    }

    public void DisableManu()
    {
        menuCanvas.enabled = false;
      

    }

    public void EnableManu()
    {
        menuCanvas.enabled = true;
        start = true;
    }


    public void DisableLevel()
    {
        Button[] buttons = firstLevel.GetComponentsInChildren<Button>();
        Text[] texts = firstLevel.GetComponentsInChildren<Text>();
        Image[] images = firstLevel.GetComponentsInChildren<Image>();

        foreach (Button component in buttons)
            component.enabled = false;

        foreach (Text component in texts)
            component.enabled = false;

        foreach (Image component in images)
            component.enabled = false;
    }

    public void EnableLevel()
    {
        Button[] buttons = firstLevel.GetComponentsInChildren<Button>();
        Text[] texts = firstLevel.GetComponentsInChildren<Text>();
        Image[] images = firstLevel.GetComponentsInChildren<Image>();

        foreach (Button component in buttons)
            component.enabled = true;

        foreach (Text component in texts)
            component.enabled = true;

        foreach (Image component in images)
            component.enabled = true;
    }
}
