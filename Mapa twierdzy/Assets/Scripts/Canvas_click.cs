using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Canvas_click : MonoBehaviour {

    // Use this for initialization
    public Sprite SelectImage;
    public Sprite ExitImage;
    Image MenuImage;
    public Button MenuButton;
    public Button gZB;
    public Button pZB;
    public Button gWB;
    public Button pWB;
    public Button wsB;
    public GameObject glowneZewnetrzne;
    public GameObject pomocniczeZewnetrzne;
    public GameObject glowneWewnetrzne;
    public GameObject pomocniczeWewnetrzne;
    public GameObject wspierajace;
    public AnimationScript animationScript;
    public GameObject mapa;

    private string name = "Słup_podswietlenie";
    private Color normal;
    private Color clicked;

    void Start()
    {
        MenuImage = GameObject.Find("Menu_image").GetComponent<Image>();
        Exit();
        Renderer[] components = mapa.GetComponentsInChildren<Renderer>();
        foreach (Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                Color newColor = new Color(1, 1, 1, 0);
                component.material.color = newColor;
            }

        }

        normal = gZB.GetComponent<Image>().color;
        clicked = new Color(0f, 0f, 0f, 0.9f);
        Debug.Log("COlor: " + normal);
    }

	public void Click_0(){
        animationScript.EnableLevel();
		
		MenuImage.sprite = ExitImage;
		MenuButton.onClick.SetPersistentListenerState(0, UnityEngine.Events.UnityEventCallState.Off);
		MenuButton.onClick.RemoveAllListeners ();
		MenuButton.onClick.AddListener (() => {
			Exit ();
		});

        GameObject menu = GameObject.Find("Menu");
        Vector3 pos = menu.transform.localPosition;
        menu.transform.localPosition = new Vector3(pos.x, -17f, pos.z);
    }

	public void Back(){
		MenuImage.sprite = ExitImage;
		MenuButton.onClick.RemoveAllListeners ();
		MenuButton.onClick.AddListener (() => {
			Exit ();
		});
	}

	public void Exit(){
		MenuImage.sprite = SelectImage;
        animationScript.DisableLevel();
        MenuButton.onClick.RemoveAllListeners ();
		MenuButton.onClick.AddListener (() => {
			Click_0 ();
		});
        GameObject menu = GameObject.Find("Menu");
        Vector3 pos = menu.transform.localPosition;
        menu.transform.localPosition = new Vector3(pos.x, -66f, pos.z);
    }

    

    public void gZ()
    {
        Image bg = gZB.GetComponentInChildren<Image>();
        Renderer[] components = glowneZewnetrzne.GetComponentsInChildren<Renderer>();
        foreach(Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                component.enabled = true;
                if (component.material.color.a < 0.5)
                {
                    component.tag = "Active";
                    StartCoroutine(FadeTo(component, 1.0f, .5f));
                    bg.color = clicked;
                }
                else
                {
                    component.tag = "Hide";
                    StartCoroutine(FadeTo(component, 0.0f, .5f));
                    bg.color = normal;
                }
            }
        }
    }

    public void pZ()
    {
        Renderer[] components = pomocniczeZewnetrzne.GetComponentsInChildren<Renderer>();
        Image bg = pZB.GetComponentInChildren<Image>();
        foreach (Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                component.enabled = true;
                if (component.material.color.a < 0.5)
                {
                    component.tag = "Active";
                    StartCoroutine(FadeTo(component, 1.0f, .5f));
                    bg.color = clicked;
                }
                else
                {
                    component.tag = "Hide";
                    StartCoroutine(FadeTo(component, 0.0f, .5f));
                    bg.color = normal;
                }
            }
        }
    }

   public void Wspier()
    {
        Renderer[] components = wspierajace.GetComponentsInChildren<Renderer>();
        Image bg = wsB.GetComponentInChildren<Image>();
        foreach (Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                component.enabled = true;
                if (component.material.color.a < 0.5)
                {
                    component.tag = "Active";
                    StartCoroutine(FadeTo(component, 1.0f, .5f));
                    bg.color = clicked;
                }
                else
                {
                    component.tag = "Hide";
                    StartCoroutine(FadeTo(component, 0.0f, .5f));
                    bg.color = normal;
                }
            }
        }
    }

    public void gW()
    {
        Image bg = gWB.GetComponentInChildren<Image>();
        Renderer[] components = glowneWewnetrzne.GetComponentsInChildren<Renderer>();
        foreach (Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                component.enabled = true;
                if (component.material.color.a < 0.5)
                {
                    component.tag = "Active";
                    StartCoroutine(FadeTo(component, 1.0f, .5f));
                    bg.color = clicked;
                }
                else
                {
                    component.tag = "Hide";
                    StartCoroutine(FadeTo(component, 0.0f, .5f));
                    bg.color = normal;
                }
            }
        }
    }

    public void pW()
    {
        Image bg = pWB.GetComponentInChildren<Image>();
        Renderer[] components = pomocniczeWewnetrzne.GetComponentsInChildren<Renderer>();
        foreach (Renderer component in components)
        {
            if (component.transform.parent.name.Equals(name))
            {
                component.enabled = true;
                if (component.material.color.a < 0.5)
                {
                    component.tag = "Active";
                    StartCoroutine(FadeTo(component, 1.0f, .5f));
                    bg.color = clicked;
                }
                else
                {
                    component.tag = "Hide";
                    StartCoroutine(FadeTo(component, 0.0f, .5f));
                    bg.color = normal;
                }
            }
        }
    }

    IEnumerator FadeTo(Renderer component, float aValue, float aTime)
    {
        float alpha = component.material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            component.material.color = newColor;
            yield return null;
        }
    }
}
