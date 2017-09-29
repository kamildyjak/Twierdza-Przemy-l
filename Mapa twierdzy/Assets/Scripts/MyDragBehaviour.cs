using UnityEngine;
using System.Collections;

public class MyDragBehaviour : MonoBehaviour 
{
	public Vector2 pozycja1_stara = Vector2.zero,
	pozycja1_nowa = Vector2.zero,
	pozycja2_stara = Vector2.zero,
	pozycja2_nowa = Vector2.zero;

	public Vector3 skalowanie_nowe = Vector3.zero;
	public float odleglosc_nowa = 0,
	odleglosc_stara = 0,
	roznica=0;
	GameObject mapa;
	

	void Start () 
	{
		mapa = GameObject.Find ("teren_ikonki");
	}
	
	// Update is called once per frame
	void Update () 
	{

		foreach (Touch touch in Input.touches) 
		{

			if(Input.touchCount > 1){
			pozycja1_nowa = Input.GetTouch(0).position;
			pozycja1_stara = pozycja1_nowa - Input.GetTouch(0).deltaPosition;
			pozycja2_nowa = Input.GetTouch(1).position;
			pozycja2_stara = pozycja2_nowa - Input.GetTouch(1).deltaPosition;
			
			odleglosc_nowa = Vector2.Distance(pozycja1_nowa,pozycja2_nowa);
			odleglosc_stara = Vector2.Distance(pozycja1_stara,pozycja2_stara);
			roznica = (odleglosc_nowa - odleglosc_stara);
			Debug.Log ("Odleglosc : " + odleglosc_nowa);
	
				if((mapa.gameObject.transform.localScale.x + (roznica/1000)) <= 0.5 && (mapa.gameObject.transform.localScale.x + (roznica/1000)) >= 0.2347965){
					mapa.gameObject.transform.localScale += new Vector3((roznica/1000),(roznica/1000),(roznica/1000));
				}
			}

		}
	}
}