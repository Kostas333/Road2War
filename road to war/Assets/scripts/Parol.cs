using UnityEngine;
using System.Collections;

public class Parol : MonoBehaviour {
	public Animator anim;
	public GameObject exclamationMark;
	public static bool GameOver=false;
	public AudioClip impact;
	AudioSource audio;
	Vector3 pos2;
	Vector3 pos1;
	int speed=2;
	public static bool moving=true;
	// Use this for initialization
	void Start () {
		anim.SetBool ("inZone", false);
		exclamationMark.SetActive (false);
		audio = GetComponent<AudioSource>();
		pos1 = this.transform.position;
		pos2=this.transform.position;
		pos1.x += 90;
		pos2.x -= 40;
	
		//transform.Translate(Vector3.up * 90, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			transform.LookAt (pos1);
			transform.position = Vector3.MoveTowards (transform.position, pos1, speed * Time.deltaTime);
		}
		//if (transform.position == pos1) {transform.position = Vector3.MoveTowards (transform.position, pos2, speed * Time.deltaTime);
		//}
		if (GameOver)
			speed = 0;
		//if (transform.position==pos1)
			//transform.position = Vector3.MoveTowards (transform.position, pos1, 1 * Time.deltaTime);
		//transform.position = pos2;
	}
	void OnTriggerEnter(Collider col){
		
		if (col.gameObject.tag == "Player") {
			Debug.Log("oh no");
			moving=false;
			exclamationMark.SetActive (true);
			transform.LookAt (FSM.playerPos);
			StartCoroutine(wait());

			anim.SetBool ("inZone", true);

			GameOver=true;
			//door=true;
		}
}
	IEnumerator wait(){
		yield return new WaitForSeconds(1f);
		audio.PlayOneShot(impact, 0.7F);
		//moving = true;

	}
}