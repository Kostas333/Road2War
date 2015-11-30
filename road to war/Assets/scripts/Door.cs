using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


	public Animator anim;
	public static bool door;

	void Start () {
		anim.SetBool ("DoorOpen", false);


	}
	
	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player") {
			Debug.Log("oh no");
			anim.SetBool ("DoorOpen", true);
			door=true;
		}


	}
}
