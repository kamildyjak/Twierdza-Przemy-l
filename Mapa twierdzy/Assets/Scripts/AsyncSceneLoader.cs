/*===============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AsyncSceneLoader : MonoBehaviour
{
    #region PUBLIC_MEMBERS
	public float loadingDelay = 5.0F;
    public string Mode = "Debug";
    public string scaneIntro;
    public string sceneNext;
    #endregion //PUBLIC_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
	{
        StartCoroutine(LoadNextSceneAfter(loadingDelay));
    }
    #endregion //MONOBEHAVIOUR_METHODS
    
    
    #region PRIVATE_METHODS
    private IEnumerator LoadNextSceneAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

		int first = PlayerPrefs.GetInt ("FirstStart");
        Debug.Log("pierwsze: " + first);
		if (first == 0) {
			#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
			Application.LoadLevel(scaneIntro);
			#else
			UnityEngine.SceneManagement.SceneManager.LoadScene(scaneIntro);
			#endif
            if(!Mode.Equals("Debug"))
                PlayerPrefs.SetInt("FirstStart", 1);

        } else {
			#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
			Application.LoadLevel(sceneNext);
			#else
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNext);
			#endif
		}
    }
    #endregion //PRIVATE_METHODS
}
