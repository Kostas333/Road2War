using UnityEngine;
using System.Collections;

public class TeamSelect : MonoBehaviour {

	public GameObject KKE;
	public GameObject China;
	public GameObject Germany;
	public GameObject Japan;
	public GameObject UK;
	public GameObject Turkey;
	public GameObject USA;
	public GameObject KKEflag;
	public GameObject Chinaflag;
	public GameObject Germanyflag;
	public GameObject Japanflag;
	public GameObject UKflag;
	public GameObject Turkeyflag;
	public GameObject USAflag;
	public GameObject Team_1;
//	public GameObject Team_2;
//	public GameObject Team_3;
//	public GameObject Team_4;
//	public GameObject Team_5;
//	public GameObject Team_6;
//	public GameObject Team_7;
	// Use this for initialization
	void Start () {
	
		KKE.SetActive (false);
		China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void KKEbtn(){
		KKE.SetActive (true);
		KKEflag.SetActive (true);
		China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		//KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	public void USAbtn(){
		USA.SetActive (true);
		USAflag.SetActive (true);
		KKE.SetActive (false);
		China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		//USAflag.SetActive (false);
		//USA.SetActive (false);
	}
	public void UKbtn(){
		UK.SetActive (true);
		UKflag.SetActive (true);
		KKE.SetActive (false);
		China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		//UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		//UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	public void Japanbtn(){
		Japan.SetActive (true);
		Japanflag.SetActive (true);
		KKE.SetActive (false);
		China.SetActive (false);
		Germany.SetActive (false);
		//Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		//Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	public void Germanybtn(){
		Germany.SetActive (true);
		Germanyflag.SetActive (true);
		KKE.SetActive (false);
		China.SetActive (false);
		//Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		//Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	public void Chinabtn(){
		China.SetActive (true);
		Chinaflag.SetActive (true);
		KKE.SetActive (false);
		//China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		//Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);
		Turkeyflag.SetActive (false);
		USAflag.SetActive (false);
	}
	public void Turkeybtn(){
		Turkey.SetActive (true);
		Turkeyflag.SetActive (true);
		KKE.SetActive (false);
		China.SetActive (false);
		Germany.SetActive (false);
		Japan.SetActive (false);
		UK.SetActive (false);
		//Turkey.SetActive (false);
		USA.SetActive (false);
		KKEflag.SetActive (false);
		Chinaflag.SetActive (false);
		Germanyflag.SetActive (false);
		Japanflag.SetActive (false);
		UKflag.SetActive (false);

		USAflag.SetActive (false);
	}

	public void GoBtn(){
		Application.LoadLevel ("Tutorial");

	}
}
