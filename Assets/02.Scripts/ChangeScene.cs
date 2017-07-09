using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("02-Menu");
		} else if (Input.GetKeyDown (KeyCode.F5)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene ("03-Stage1");
	}
}
