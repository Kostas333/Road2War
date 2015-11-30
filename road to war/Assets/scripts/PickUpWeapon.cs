using UnityEngine;
using System.Collections;

public class PickUpWeapon : MonoBehaviour {

	public GameObject arrow;
	public AudioClip impact;
	AudioSource audio;
	bool once=true;
	public static bool picked;
	void Start(){
		arrow.SetActive (true);
		audio = GetComponent<AudioSource>();
	
	}

	void Update () {
		if (AutoTypingText.textnumber==3) {
			if(once){
				arrow.SetActive(true);
				once=false;
			}

		
		}

	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Grenade") {
			Debug.Log("grenade");
			ItemSelection.instance.IndexWeapon(0);
			picked=true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Pistol") {
			audio.PlayOneShot(impact, 0.7F);
			Debug.Log("pistol");
			ItemSelection.instance.IndexWeapon(1);
			picked=true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Rocket_Launcher") {
			Debug.Log("RocketLauncher");
			ItemSelection.instance.IndexWeapon(2);
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Rifle") {
			audio.PlayOneShot(impact, 0.7F);
			Debug.Log("Rifle");
			ItemSelection.instance.IndexWeapon(3);
			picked=true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Arrow") {
			Debug.Log("grenade");
			//ItemSelection.instance.IndexWeapon(0);
			Destroy(col.gameObject);
		}
	}
	
		
}
