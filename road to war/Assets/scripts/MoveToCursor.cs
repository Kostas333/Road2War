using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveToCursor : MonoBehaviour {
	public GameObject Enemy;
	public bool selected;
	private float speed=10;
	private Vector3 targetPosition;
	public  bool isMoving;
	Animator anim;
	public GameObject inventory;
	public GameObject halo;
	const int LEFT_MOUSE_BUTTON=0;
	public static bool enemy_selected;
	//private float acceleration;

	void Start () {

		
			inventory.SetActive (false);
			anim = GetComponent <Animator> ();
			targetPosition = transform.position;
			isMoving = false;

			halo.SetActive (false);
	}
	

	void Update () {
		  //checks if UI is over the terrain
			if (selected) {
			#if UNITY_EDITOR
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
				#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
			if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(0)) {
				#endif
				inventory.SetActive (true);
				halo.SetActive (true);
					#if UNITY_EDITOR
					if (Input.GetMouseButton (LEFT_MOUSE_BUTTON) ) 
						#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
						if (/*Input.GetMouseButton (LEFT_MOUSE_BUTTON)||*/  ( Input.touchCount ==1 && Input.GetTouch(0).phase == TouchPhase.Began) ) 
							#endif
				
					SetTargetPos ();
		
			}
		} else {
			halo.SetActive (false);
			inventory.SetActive (false);
		}
		if (isMoving)
			MovePlayer ();

	}


	public void SetTargetPos(){

		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray;
		//for unity editor
		#if UNITY_EDITOR
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//for touch device
		#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
		ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		#endif
		float point = 0.0f;

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

			if (hit.collider.tag == "Enemy") {
				
					if(ItemSelection.check)
					{
						Debug.Log ("enemy");
						enemy_selected=true;
					}
					isMoving=false;
					}
		

		else if (plane.Raycast (ray, out point)){
			targetPosition = ray.GetPoint (point);
			isMoving = true;
			enemy_selected=false;
		}
			}}

	void MovePlayer(){
	
		transform.LookAt (targetPosition);
		transform.position = Vector3.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		anim.SetFloat ("speed",Mathf.Abs (speed*Time.deltaTime));
		if (transform.position == targetPosition) {
			isMoving = false;
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
}
