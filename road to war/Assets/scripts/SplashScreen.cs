using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	void Start () {
		StartCoroutine("WaitThreeSeconds");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	IEnumerator WaitThreeSeconds(){
		
		yield return new WaitForSeconds(4);
		Application.LoadLevel ("MainMenu");
	}
}

