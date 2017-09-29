using UnityEngine;
using System.Collections;
public class Buttons_click : MonoBehaviour {
	
	public void Pierscien_z_g(){
		Debug.Log ("Button clicked");
		Renderer[] renderer = GameObject.Find ("glowne").GetComponentsInChildren<Renderer> ();
		int size = renderer.Length;
		foreach (Renderer component in renderer) {
			if(component.name.Equals("Object001") || component.name.Equals("Tube001")){
				component.enabled = true;
				if(component.material.color.a < 0.5)
					StartCoroutine(FadeTo(component,1.0f, .5f));
				else
					StartCoroutine(FadeTo(component,0.0f, .5f));
			}
		}
	}

	public void Pierscien_z_p(){
		Debug.Log ("Button clicked");
		Renderer[] renderer = GameObject.Find ("pomocniecze").GetComponentsInChildren<Renderer> ();
		int size = renderer.Length;
		foreach (Renderer component in renderer) {
			if(component.name.Equals("Object001") || component.name.Equals("Tube001")){
				component.enabled = true;
				if(component.material.color.a < 0.5)
					StartCoroutine(FadeTo(component,1.0f, .5f));
				else
					StartCoroutine(FadeTo(component,0.0f, .5f));
			}
		}
	}

	public void Pierscien_wspierajacy(){
		Debug.Log ("Button clicked");
		Renderer[] renderer = GameObject.Find ("wspierajace").GetComponentsInChildren<Renderer> ();
		int size = renderer.Length;
		foreach (Renderer component in renderer) {
			if(component.name.Equals("Object001") || component.name.Equals("Tube001")){
				component.enabled = true;
				if(component.material.color.a < 0.5)
					StartCoroutine(FadeTo(component,1.0f, .5f));
				else
					StartCoroutine(FadeTo(component,0.0f, .5f));
			}
		}
	}

	public void Pierscien_w_g(){
		Debug.Log ("Button clicked");
		Renderer[] renderer = GameObject.Find ("wew_duze").GetComponentsInChildren<Renderer> ();
		int size = renderer.Length;
		foreach (Renderer component in renderer) {
			if(component.name.Equals("Object001") || component.name.Equals("Tube001")){
				component.enabled = true;
				if(component.material.color.a < 0.5)
					StartCoroutine(FadeTo(component,1.0f, .5f));
				else
					StartCoroutine(FadeTo(component,0.0f, .5f));
			}
		}
	}

	public void Pierscien_w_p(){
		Debug.Log ("Button clicked");
		Renderer[] renderer = GameObject.Find ("wew_male").GetComponentsInChildren<Renderer> ();
		int size = renderer.Length;
		foreach (Renderer component in renderer) {
			if(component.name.Equals("Object001") || component.name.Equals("Tube001")){
				component.enabled = true;
				if(component.material.color.a < 0.5)
					StartCoroutine(FadeTo(component,1.0f, .5f));
				else
					StartCoroutine(FadeTo(component,0.0f, .5f));
			}
		}
	}

	IEnumerator FadeTo(Renderer component,float aValue, float aTime)
	{
		float alpha = component.material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			component.material.color = newColor;
			yield return null;
		}
	}
	
}
