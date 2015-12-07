using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public enum StateType
{
	IDLE,
	WALKING,
	SHOOTING,
	DEAD
	
	// ...
};

public class FSM : MonoBehaviour {

	//public Transform destination;

	//private NavMeshAgent agent;
	public AudioClip shoot;
	AudioSource audio;
	public static bool once=true;
	public static bool once2=true;
	private int ShootWith;
	public GameObject outOfRange;
	public static bool enemydead;
	public GameObject Eff_Burst_1_oneShot;
	public static Vector3 targetPos;
	private Vector3 captainPos;
	public static bool distTrue;
	//public GameObject Enemy;
	public static float distance;
	public GameObject blood;
	bool picked;
	Animator anim;
	public static float ShootTime ;
	public static bool changeplayer;
	public bool selected;
	public float speed;
	private Vector3 targetPosition;
	public static Vector3 playerPosition;
	public  bool isMoving;
	public static bool endpick;
	public GameObject inventory;
	public GameObject halo;
	const int LEFT_MOUSE_BUTTON=0;
	public static bool enemy_selected;
	public static Vector3 playerPos;
	int x=0;
	public StateType ActiveState=StateType.IDLE;
	public static bool shootmthf;
	public static bool canmove;

	void Start () {
		endpick = false;
//		for(int y =0;y<=3;y++)
//		{
//			Enemy[y].SetActive (false);
//		}
//		agent = gameObject.GetComponent<NavMeshAgent>();
		
		//agent.SetDestination(destination.position);
		audio = GetComponent<AudioSource>();
		outOfRange.SetActive(false);
		//shootButton.SetActive (true);
		ItemSelection itemselect=GetComponent <ItemSelection>();
		//Enemy = GameObject.FindWithTag("Enemy");
		anim = GetComponent <Animator>();
		targetPos = transform.position;
		inventory.SetActive (false);
		anim = GetComponent <Animator> ();
		targetPosition = transform.position;
		isMoving = false;
		
		halo.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		playerPosition = transform.position;
		if (!canmove) {
			return;
		}
		//Time.timeScale = 0;
		if (Parol.GameOver) {
			ActiveState = StateType.DEAD;
		}
		if (LookAtPlayer.killninja) {
			distTrue=true;
			//distance = Vector3.Distance (MainChar.transform.position, enemyPos );
			//CheckWeapon ();
			ShootWith=2;
			enemy_selected=true;
			//if(distTrue)
			ActiveState = StateType.SHOOTING;

		}
		if (enemyScript1.kill) {
			distTrue=false;
			//distance = Vector3.Distance (MainChar.transform.position, enemyPos );
			CheckWeapon ();
			if(distTrue)
			ActiveState = StateType.SHOOTING;
		}
		if(CountDown.timesUp&&this.gameObject.name=="China_Typical_Soldier")
			ActiveState = StateType.DEAD;
		//ShootTime = 1;
		//
//		if (ItemSelection.check && enemy_selected) {
//			shootButton.SetActive (true);
//		}
//		else
//			shootButton.SetActive (false);
		if (selected&&ActiveState!=StateType.SHOOTING) {
			#if UNITY_EDITOR
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
				#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
				if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0)) {
				#endif
				inventory.SetActive (true);
				halo.SetActive (true);
				endpick=true;
					if(gameObject.name=="China_Typical_Soldier")
						changeplayer=true;
				#if UNITY_EDITOR
				if (Input.GetMouseButton (LEFT_MOUSE_BUTTON)) {
						if(this.gameObject.name=="China_Typical_Soldier"){
							if(CountDown.timesUp){
								Debug.Log("DEAD");
							}
							
							else{
							SetTargetPos ();
							ActiveState = StateType.WALKING;

							}
				}
						else{
							SetTargetPos ();
							ActiveState = StateType.WALKING;
						}}
				#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
					if (/*Input.GetMouseButton (LEFT_MOUSE_BUTTON)||*/  ( Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Began) ){
						SetTargetPos ();
						ActiveState=StateType.WALKING;
						
						
					} 
				#endif
							
							
					
			}
		} else {
			halo.SetActive (false);
			inventory.SetActive (false);
		}
	
	

		switch (ActiveState) {
		case StateType.IDLE:
			{
				anim.SetBool ("isPistol", false);
				anim.SetBool ("isGernade", false);
				anim.SetBool ("isAK47", false);
				anim.SetBool ("isRPG", false);
//			}
		}
		//check for numActions > MaxActions
		break;
	
		case StateType.WALKING:
		{
				MovePlayer ();

				
				}
			
		break;
			case StateType.SHOOTING:{
				anim.SetFloat ("speed",Mathf.Abs (0));
				Debug.Log("shoot");
				Shoot();
				StartCoroutine(idletime ());

			}
			break;
			case StateType.DEAD:{
				anim.SetFloat ("speed",Mathf.Abs (0));
				anim.SetBool ("isdead", true);
				StartCoroutine(death ());
				blood.SetActive(false);
				
			}
				break;
	}
		
		}
	
	

	public void SetTargetPos(){
		
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray;
		//for unity editor
		#if UNITY_EDITOR
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//for touch device
		#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
		ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		#endif
		float point = 0.0f;
		
		RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
			//foreach (GameObject enemy in Enemy)
			//	{
				
			if (hit.collider.tag == "Enemy") {

			}
	
			else if (plane.Raycast (ray, out point)) {
				targetPosition = ray.GetPoint (point);
				//isMoving = true;
				//agent.SetDestination(hit.point);

				enemy_selected = false;

			}
		}
		}
	
	void MovePlayer(){
		
		transform.LookAt (targetPosition);
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
			playerPos = transform.position;
			anim.SetFloat ("speed",Mathf.Abs (speed*Time.deltaTime));
		if (transform.position == targetPosition) {
			//isMoving = false;
			anim.SetFloat ("speed",Mathf.Abs (0));
		}
		Debug.DrawLine (transform.position, targetPosition, Color.red);
		
	}
	public void selectplayer()
	{
		selected = true;
	}
	public void deselectplayer()
	{
		selected = false;
	}
//	public void ButtonShoot(){
//		
//			ActiveState = StateType.SHOOTING;
//		
//	}
	
	
	void CheckWeapon(){
		if (ItemSelection.WeaponSelected == 2) {
			//SetTargetPos ();
			
			if (Mathf.Abs (distance) < 14) {
				Debug.Log ("mpika");
				distTrue = true;
					ShootWith=1;
				//MoveToCursor.isMoving = false;
				

			} else {
					
				outOfRange.SetActive (true);
				StartCoroutine (waitRange ());
			}
		}
		if (ItemSelection.WeaponSelected == 1) {
			if (Mathf.Abs (distance) < 14) {			
				distTrue = true;
					ShootWith=2;
			} else {
					
				outOfRange.SetActive (true);
				StartCoroutine (waitRange ());
			}
		}
		if (ItemSelection.WeaponSelected == 4) {
			if (Mathf.Abs (distance) < 37) {
				distTrue = true;

					ShootWith=3;
			} else {
					distTrue = false;
				outOfRange.SetActive (true);
				StartCoroutine (waitRange ());
			}
		}
		if (ItemSelection.WeaponSelected == 3) {
			if (Mathf.Abs (distance) < 37) {
				distTrue = true;
					ShootWith=4;
			} else {
					distTrue = false;
				outOfRange.SetActive (true);
				StartCoroutine (waitRange ());
			}
		}
	}


			void Shoot(){

			if(enemy_selected&&ShootWith==1){

						targetPos=enemyScript1.enemyPos;
					enemyScript1.kill=true;
					//particle.SetActive(true);
					//Instantiate (Eff_Burst_1_oneShot, Enemy.transform.position, Enemy.transform.rotation);
					transform.LookAt(targetPos);
					//transform.LookAt (targetPos);
				if(once2){
					audio.PlayOneShot(shoot, 0.7F);
					once2=false;
				}
					audio.PlayOneShot(shoot, 0.7F);
					Debug.Log ("shoot the bastard");
					ItemSelection.check=false;
					StartCoroutine(wait2());
					
					//	ItemSelection.WeaponSelected = -1;
				}
				else{
						Debug.Log ("asd");
					}
			
			
		
		
					if(enemy_selected&&ShootWith==2){
						transform.LookAt (LookAtPlayer.enemyPos);
				anim.SetBool ("isGernade", true);
				audio.PlayOneShot(shoot, 0.7F);
					//	enemyScript1.PlayDead();
				Debug.Log ("shoot the bastard");
				//ItemSelection.WeaponSelected = -1;
				ItemSelection.check = false;
				StartCoroutine(wait2());
					}

	
					if(enemy_selected&&ShootWith==3){
						transform.LookAt (enemyScript1.enemyPos);
				anim.SetBool ("isAK47", true);

					//	enemyScript1.PlayDead();
				Debug.Log ("shoot the bastard");
				//ItemSelection.WeaponSelected = -1;
				ItemSelection.check = false;
				ShootWith=0;
				shootmthf=true;
				enemy_selected = false;
				StartCoroutine(wait2());
			
					}
		
		
				if (enemy_selected&&ShootWith==4) {
					transform.LookAt (enemyScript1.enemyPos);
					anim.SetBool ("isRPG", true);
					//	enemyScript1.PlayDead();
					Debug.Log ("shoot the bastard");
					shootmthf=true;
					//ItemSelection.WeaponSelected = -1;
					ItemSelection.check = false;
				}

		
			}
			IEnumerator wait2(){
				//enemydead = true;
				yield return new WaitForSeconds(0.6f);
				//ActiveState = StateType.IDLE;

			if (x < 1) {
				if(once){
					audio.PlayOneShot(shoot, 0.7F);
					once=false;
				}
				Instantiate (Eff_Burst_1_oneShot,enemyScript1.enemyPos, enemyScript1.enemyRot);
				once=true;


			}
				x++;

			enemyScript1.kill=false;
			StartCoroutine (twosec());
				//Debug.Log (x);
			}
			IEnumerator idletime(){
				
				yield return new WaitForSeconds(1f);
				ActiveState = StateType.IDLE;
				
				
			}
			IEnumerator waitRange(){
			distTrue=false;

			enemyScript1.kill = false;
			ActiveState = StateType.IDLE;
			yield return new WaitForSeconds(2f);
			outOfRange.SetActive (false);


			
		}
		IEnumerator twosec(){
			yield return new WaitForSeconds(2f);
			x=0;
	}
		IEnumerator death(){
			yield return new WaitForSeconds(10f);

		
		}
		
	}

