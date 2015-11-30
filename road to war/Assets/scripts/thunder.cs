using UnityEngine;
using System.Collections;

public class thunder : MonoBehaviour {
	bool thunders;
	public AudioClip thunderl;
	public Light light;
	private float lastTime = 0;
	private float thresh=0.5f;
	private float minTime=0.5f;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	void Update () {
		if (thunders) {

			if (Random.value > thresh)
				light.intensity = 1.3f;
			else
				light.intensity = 0.3f;
			lastTime = Time.time;
			StartCoroutine(twosec());
		}
		else
		light.intensity = 0.3f;
	}
	

	// Update is called once per frame

	void OnTriggerEnter(Collider col){
		
		if (col.gameObject.tag == "Player") {
			Debug.Log("oh no");


			thunders=true;
			//lighting.intensity=1.3f;
			audio.PlayOneShot(thunderl, 0.7F);

		}
		
		
	}
	IEnumerator twosec(){
		yield return new WaitForSeconds(2f);
		thunders = false;

	}
}
