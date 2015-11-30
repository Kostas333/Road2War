using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public BoxCollider col;
	Animator anim;
	public static bool pass=false;
	public GameObject MainChar;
	public static Vector3 enemyPos;
	public static Quaternion enemyRot;
	public static bool killninja;
	public static int killcount=0;
	//public static bool interactable=true;
	//public static bool loot=false;
	void Start () {
		
		//GetComponent(MeshFilter).mesh;
		
		anim = GetComponent <Animator> ();
		//col=gameObject.GetComponent(MeshCollider);
	}
	
	void Update()
	{transform.LookAt (FSM.playerPos);
		//Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray;
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
			
			if (hit.collider.gameObject == this.gameObject) {
				enemyPos = transform.position;
				enemyRot = transform.rotation;
				
				
				//Debug.Log(enemyPos);
				FSM.distance = Vector3.Distance (MainChar.transform.position, enemyPos );
				//
				//FSM.enemy_selected = true;
				//interactable = false;
				//loot = true;
				if (ItemSelection.check) {
					killninja=true;
					
					if(FSM.distTrue){
						this.anim.SetBool ("isDead", true);
						pass=true;
						killcount++;
						Destroy (col);
						FSM.enemy_selected = true;
						Debug.Log ("enemy");
						FSM.distTrue=false;
						//kill=false;
						FSM.shootmthf=false;
						//DestroyObject(gameObject);
					}
					//enemy_selected = true;
					//col.enabled=false;
				}
			}
		}
		
	}
	
}
