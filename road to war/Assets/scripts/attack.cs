using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attack : MonoBehaviour {

	public GameObject shootButton;

	public static bool shoottance;
	public GameObject Eff_Burst_1_oneShot;
	private Vector3 targetPos;
	private Vector3 captainPos;
 	public GameObject Enemy;
	float distance;
	bool picked;
	Animator anim;
	float ShootTime =2;

	// Use this for initialization
	void Start () 
	{
		//particle.SetActive (false);
		shootButton.SetActive (false);
		ItemSelection itemselect=GetComponent <ItemSelection>();
		//Enemy = GameObject.FindWithTag("Enemy");
		anim = GetComponent <Animator>();
		targetPos = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{


		if(ItemSelection.check&&MoveToCursor.enemy_selected)
			shootButton.SetActive (true);
		else
			shootButton.SetActive (false);

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("BlankState")) {
			anim.SetBool ("isPistol", false);
			anim.SetBool ("isGernade", false);
			anim.SetBool ("isAK47", false);
			anim.SetBool ("isRPG", false);
		}
//		ShootTime += Time.deltaTime;
		distance = Vector3.Distance (transform.position, Enemy.transform.position);


		}



	public void ButtonShoot(){

	CheckWeapon ();

	}


	void CheckWeapon(){
		   if (ItemSelection.WeaponSelected == 2) {
			//SetTargetPos ();
		
			if (Mathf.Abs(distance) < 22) {
				//MoveToCursor.isMoving = false;
				if(MoveToCursor.enemy_selected){
					//particle.SetActive(true);
					//Instantiate (Eff_Burst_1_oneShot, Enemy.transform.position, Enemy.transform.rotation);
				transform.LookAt(Enemy.transform.position);
				//transform.LookAt (targetPos);
				anim.SetBool ("isPistol", true);
				ShootTime = 0;
				Debug.Log ("shoot the bastard");
				ItemSelection.check=false;
					StartCoroutine(wait2());
				
			//	ItemSelection.WeaponSelected = -1;
				}
				else
					Debug.Log("enemy not selected");
			}
			else 
				Debug.Log ("Enemy out of Range");
		}

		
		if (ItemSelection.WeaponSelected == 1) {
			if (Mathf.Abs (distance) < 24) {
				transform.LookAt (Enemy.transform.position);
				anim.SetBool ("isGernade", true);
				ShootTime = 0;
				Debug.Log ("shoot the bastard");
				//ItemSelection.WeaponSelected = -1;
				ItemSelection.check = false;
			}
		}
		if (ItemSelection.WeaponSelected == 4) {
			if (Mathf.Abs (distance) < 37) {
				transform.LookAt (Enemy.transform.position);
				anim.SetBool ("isAK47", true);
				ShootTime = 0;
				Debug.Log ("shoot the bastard");
				//ItemSelection.WeaponSelected = -1;
				ItemSelection.check = false;
				StartCoroutine(wait2());
			}
		}
	
		if(ItemSelection.WeaponSelected==3)
		{
			if (Mathf.Abs (distance) < 37) {
			transform.LookAt (Enemy.transform.position);
			anim.SetBool("isRPG",true);
			ShootTime = 0;
			Debug.Log("shoot the bastard");
			//ItemSelection.WeaponSelected = -1;
			ItemSelection.check=false;
			}
		}

	}

//	public void SetTargetPos(){
//		
//		Plane plane = new Plane (Vector3.up, transform.position);
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		float point = 0;
//		
//		if (plane.Raycast (ray, out point))
//			targetPos = ray.GetPoint (point);
//		Debug.DrawLine(transform.position,targetPos,Color.green);
//
//	}

	IEnumerator wait2(){

		yield return new WaitForSeconds(1f);
		Instantiate (Eff_Burst_1_oneShot, Enemy.transform.position, Enemy.transform.rotation);
	}
}
