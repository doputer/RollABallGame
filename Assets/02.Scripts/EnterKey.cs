using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterKey : MonoBehaviour {

	public Canvas KeyInfoCanvas;

	public void KeyInfoBtnOpen()
	{
		KeyInfoCanvas.enabled = true;
	}

	public void KeyInfoBtnClose()
	{
		KeyInfoCanvas.enabled = false;
	}
}
