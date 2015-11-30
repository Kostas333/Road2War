using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialHelper : MonoBehaviour {

	public GameObject arrow;

	public GameObject closedDoor;
	public GameObject playerPickCaptain;
	public GameObject playerPickSoldier1;
	public GameObject playerPickSoldier2;
	public GameObject Enemy1;
	public GameObject Enemy2;
	//public GameObject Enemy3;
	public GameObject Textfade;
	public GameObject Completed;
	public GameObject Proceed;
	//public static bool callNinja;
	bool once=true;
	bool once2=true;
	bool once3=true;
	int y=0;
	void Awake () {
		arrow.SetActive (false);
		playerPickCaptain.SetActive (false);
		StartCoroutine(Wait());
	}
	//public GameObject Enemy3;
	// Use this for initialization
	void Start () {

		Enemy1.SetActive (true);
		Enemy2.SetActive (false);
		//Enemy3.SetActive (false);
		Completed.SetActive (false);
		//Enemy3.SetActive (false);
		Proceed.SetActive (false);
		//callNinja = true;

		playerPickSoldier1.SetActive (false);
		playerPickSoldier2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


			
		
			


			

		if (GameController.captainTrue) {
		//	Textfade.SetActive (false);
			GameController.captainTrue = false;
			arrow.SetActive (false);
		}
		if (PickUpWeapon.picked) {
			if (once) {
				//Textfade.SetActive (true);
				once = false;
			}
		}
		if (ItemSelection.check) {
			if (once3) {
				//StartCoroutine(wait ());
				//Textfade.SetActive (false);
				once3 = false;
			}
			Enemy1.SetActive (true);
		}
		if (enemyScript1.pass) {
			Enemy2.SetActive (true);
			enemyScript1.pass=false;
			y++;
//			if (once2) {
//				StartCoroutine(wait ());
//
//				once2 = false;
//			}

			//StartCoroutine(wait());

		}
		if (enemyScript1.killcount == 2) {

			//Textfade.SetActive (true);
			if(y==2){
				StartCoroutine(wait());


			}
		}
	}
//		

	IEnumerator wait(){
		Debug.Log ("odsi");
		yield return new WaitForSeconds(3f);
		Textfade.SetActive (true);
		Completed.SetActive (true);
		
		Proceed.SetActive (true);

		//if(y==0)
		//Time.timeScale = 0;

		//Textfade.SetActive (true);
		//y++;
		//playerPickSoldier1.SetActive (true);

	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(3f);
		arrow.SetActive (true);
		playerPickCaptain.SetActive (true);
	}
	public void OnPulsingButtonClicked()
	{
		//AutoTypingText.textnumber = 8;
		GameController.captainTrue = false;
		AutoTypingText.textnumber = 0;
		PickUpWeapon.picked = false;
		ItemSelection.check = false;
		enemyScript1.pass = false;
		enemyScript1.killcount = 0;
		arrow.SetActive (false);
		once = false;
		once2 = false;
		once3 = false;
		Door.door = false;
		Parol.GameOver = false;
		GameController.soldierTrue = false;
		Completed.SetActive (false);
		Proceed.SetActive (false);

		playerPickCaptain.SetActive (false);
		playerPickSoldier1.SetActive (false);
		playerPickSoldier2.SetActive (false);
		AutoTypingText.textnumber = 0;
		Application.LoadLevel ("Scene2");
		
		
	}
	public void OnHomeButtonClicked()
	{
		GameController.captainTrue = false;
		AutoTypingText.textnumber = 0;
		PickUpWeapon.picked = false;
		ItemSelection.check = false;
		enemyScript1.pass = false;
		enemyScript1.killcount = 0;
		arrow.SetActive (false);
		once = false;
		once2 = false;
		once3 = false;
		Door.door = false;
		Parol.GameOver = false;
		GameController.soldierTrue = false;
		Completed.SetActive (false);
		Proceed.SetActive (false);

		playerPickCaptain.SetActive (true);
		playerPickSoldier1.SetActive (false);
		playerPickSoldier2.SetActive (false);
		AutoTypingText.textnumber = 0;
		Application.LoadLevel ("MainMenu");
		
		
	}
}
