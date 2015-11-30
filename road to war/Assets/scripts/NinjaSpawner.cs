using UnityEngine;
using System.Collections;

public class NinjaSpawner : MonoBehaviour {

	public GameObject ninja;
	//public int amount;
	bool spawnplz=true;
	private Vector3 spawnpoint1= new Vector3(245.32f,1f,220f);
	private Vector3 spawnpoint2= new Vector3(79f,1f,172.5f);
	private Vector3 spawnpoint3= new Vector3(303f,1f,302f);
	private Vector3 spawnpoint4= new Vector3(361f,-2.9f,143.7f);
	private Vector3 spawnpoint5= new Vector3(283.9f,4.3f,185f);
	private Vector3 spawnpoint6= new Vector3(409f,1f,304f);
	public static int x;
	private bool once=true;
	// Use this for initialization
	void Start () {
		//ninja = GameObject.FindGameObjectWithTag ("Ninja");
	}
	
	// Update is called once per frame
	void Update () {

			if (enemyScript1.ninjaSpawn) {
			if (once) {
				Debug.Log ("plz spawn");
				spawnNinja ();
				once = false;
			}

		}
//		ninja.transform.LookAt (FSM.playerPos);
	//	ninja = GameObject.FindGameObjectWithTag ("Ninja");
		if(spawnplz){
			spawnNinja();
			spawnplz=false;
		}
	}

	public void spawnNinja(){

		x=Random.Range (1, 7);
		if (x == 1 && enemyScript1.ninjapos != 1)
			Instantiate (ninja, spawnpoint1, Quaternion.identity);
//		else if (x == 1 && enemyScript1.ninjapos == 1)
//			spawnNinja ();
		if (x==2&&enemyScript1.ninjapos!=2)
			Instantiate(ninja,spawnpoint2, Quaternion.identity);
//		else if (x == 2 && enemyScript1.ninjapos == 2)
//			spawnNinja ();
		if (x==3&&enemyScript1.ninjapos!=3)
			Instantiate(ninja,spawnpoint3, Quaternion.identity);
//		else if (x == 3 && enemyScript1.ninjapos == 3)
//			spawnNinja ();
		if (x==4&&enemyScript1.ninjapos!=4)
			Instantiate(ninja,spawnpoint4, Quaternion.identity);
//		else if (x == 4 && enemyScript1.ninjapos == 4)
//			spawnNinja ();
		if (x==5&&enemyScript1.ninjapos!=5)
			Instantiate(ninja,spawnpoint5, Quaternion.identity);
//		else if (x == 5 && enemyScript1.ninjapos == 5)
//			spawnNinja ();
		if (x==6&&enemyScript1.ninjapos!=6) 
			Instantiate(ninja,spawnpoint6, Quaternion.identity);
//		else if (x == 6 && enemyScript1.ninjapos == 6)
//			spawnNinja ();
		//ninja.transform.LookAt (FSM.playerPos);
		Debug.Log(x);
	}
}
