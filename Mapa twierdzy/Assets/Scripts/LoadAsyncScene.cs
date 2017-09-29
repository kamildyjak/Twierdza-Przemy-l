/*===============================================================================
Copyright (c) 2016 PTC Inc. All Rights Reserved.
Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.
===============================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadAsyncScene: MonoBehaviour
{
	#region PUBLIC_MEMBERS
	public float loadingDelay = 5.0F;
	#endregion //PUBLIC_MEMBERS


	#region MONOBEHAVIOUR_METHODS
	#endregion //MONOBEHAVIOUR_METHODS


	#region PRIVATE_METHODS
	public IEnumerator LoadNextSceneAfter(float seconds, string scene)
	{
		yield return new WaitForSeconds(seconds);

		#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
		Application.LoadLevelAsync(Application.loadedLevel+1);
		#else
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene);
		#endif
	}
	#endregion //PRIVATE_METHODS
}
