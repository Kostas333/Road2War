using UnityEngine;
using System.Collections;

public class Scene2Helpet : MonoBehaviour {

	public GameObject arrow;
	public GameObject timer;
	public GameObject closedDoor;
	public GameObject playerPickCaptain;
	public GameObject playerPickSoldier1;
	public GameObject playerPickSoldier2;
	public GameObject Failed;
	//public GameObject Enemy2;
	public GameObject Textfade;
	public GameObject Completed;
	public GameObject Proceed;
	bool once=true;
	bool once2=true;
	bool once3=true;
	int y=0;
	//public GameObject Enemy3;
	// Use this for initialization
	void Start () {
		arrow.SetActive (false);
		timer.SetActive (false);
		//Enemy1.SetActive (false);
		//Enemy2.SetActive (false);
		Completed.SetActive (false);
		//Enemy3.SetActive (false);
		Proceed.SetActive (false);
		Failed.SetActive (false);
		playerPickCaptain.SetActive (true);
		playerPickSoldier1.SetActive (false);
		playerPickSoldier2.SetActive (false);
		type2.textnumber = 0;
		StartCoroutine (wait ());
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {

		if (GameController.soldierTrue) {

			if(once2){
			
			Textfade.SetActive (false);
				timer.SetActive(true);
				once2=false;}
			arrow.SetActive (false);
		//	timer.SetActive(true);
		}

		if (Door.door) {
			if(once){
			StartCoroutine (wait2 ());
				once=false;
			}
		}

		if (Parol.GameOver||CountDown.timesUp) {
		
			if(once3){
				StartCoroutine (wait3 ());
				timer.SetActive(false);
				once3=false;
			}
		}
	}

	IEnumerator wait(){

		yield return new WaitForSeconds(2f);
		playerPickSoldier1.SetActive (true);
		arrow.SetActive (true);
	}
	IEnumerator wait2(){
		
		yield return new WaitForSeconds(3f);
		Textfade.SetActive (true);
		Completed.SetActive (true);
		timer.SetActive (false);
		Proceed.SetActive (true);
	}
	IEnumerator wait3(){
		
		yield return new WaitForSeconds(3f);
		Textfade.SetActive (true);
		Failed.SetActive (true);
	}

	public void OnHomeButtonClicked()
	{
		CountDown.timesUp = false;
		Parol.moving = true;
		arrow.SetActive (false);
		once = true;
		once2 = true;
		once3 = true;
		Textfade.SetActive (true);
		Door.door = false;
		Parol.GameOver = false;
		GameController.soldierTrue = false;
		GameController.captainTrue = false;
		Completed.SetActive (false);
		Proceed.SetActive (false);
		Failed.SetActive (false);
		playerPickCaptain.SetActive (true);
		playerPickSoldier1.SetActive (false);
		playerPickSoldier2.SetActive (false);
		AutoTypingText.textnumber = 0;
		Application.LoadLevel ("MainMenu");
		
		
	}
	public void ProceedBtn(){

		Application.LoadLevel ("LookAround");
	}
}
