using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	bool paused=false;
	public GameObject menu;
	// Use this for initialization
	void Start () {
		menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public void pausedButton(){
		menu.SetActive (true);
		Time.timeScale = 0;

	}
	public void returnButton(){

		menu.SetActive (false);
		Time.timeScale = 1;
	}
}
