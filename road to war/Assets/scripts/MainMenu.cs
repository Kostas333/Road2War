using UnityEngine;
using System.Collections;
using UIAddons;
using System;
using System.Linq;


public class MainMenu : MonoBehaviour {

	public RectTransform pulsingButton;
	//public RectTransform rollingText;

	// Use this for initialization
	void Start () {
		//UITools.StartPulseEffect(pulsingButton, 1.2f, 0.8f, delay: 4f);
	
	}
	

	public void OnPulsingButtonClicked()
	{

		Application.LoadLevel ("TeamSelection");
		

	}
}
