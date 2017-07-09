using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLogoScene : MonoBehaviour {

	private float delayTime = 3.0f;

	void Update()
	{
		delayTime -= Time.deltaTime;

		if (delayTime <= 0) {
				SceneManager.LoadScene ("02-Menu");
		}
	}
}
