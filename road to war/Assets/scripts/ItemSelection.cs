using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemSelection : MonoBehaviour {

	public GameObject[] WeaponRange;
	public  Image[] ImageSelection;
	public  List<Sprite> ItemList= new List<Sprite>();
	private  int itemSpot=0;
	public int[] num_weapon;
	public static int WeaponSelected;//=-1;
	public static ItemSelection instance;
	private int i=0;
	private int y=0;
	private int z=0;
	public static bool check=false;
	private bool deactivated = false;

	void Awake(){
		//WeaponRange = new GameObject[4];

		num_weapon = new int[4];
		instance = this;
		for(int y =0;y<=3;y++)
		{
			WeaponRange[y].SetActive (false);
		}
	
	}
	public void IndexWeapon(int num){
	
		ImageSelection[itemSpot].sprite = ItemList [num];
		num_weapon[i] = num;
		itemSpot++;
		i++;
	}
	void Update(){

		if (!check) {
		
			for(z=0;z<=3;z++){

				WeaponRange[z].SetActive(false);
			}
		
		}
		//		ImageSelection[0].sprite = ItemList [itemSpot];
	}
	public void FirstWeaponEquip(){

//		if (WeaponSelected == 1&&!deactivated)
//			Deactivate (0);
//		else
		if (PickUpWeapon.picked) {
			if (check) {
				Deactivate (0);
				check = false;
				FSM.once = true;
				FSM.once2 = true;
			} else{
				EquipWeapon (num_weapon [0]);
				Debug.Log("WEAPON ACTIVATED");
			}
		}
	}

//	public void SecondWeaponEquip(){
//		if(PickUpWeapon.picked){
//		if (check) {
//			Deactivate (1);
//			check = false;
//			FSM.once=true;
//			FSM.once2=true;
//		}
//		else
//		EquipWeapon (num_weapon [1]);
//		
//		}}
//	public void ThirdWeaponEquip(){
//
//		if (check) {
//			Deactivate (2);
//			check = false;
//		}
//		else
//		EquipWeapon (num_weapon [2]);
//	}
//	public void FourthWeaponEquip(){
//
//		if (check) {
//			Deactivate (3);
//			check = false;
//		}
//		else
//		EquipWeapon (num_weapon [3]);
//	}

	void EquipWeapon(int wNum){

		if (wNum == 0) {

			ShowRange(wNum);
			Debug.Log ("1st weapon equipped");
			WeaponSelected=1;
			check = true;
		} else if (wNum == 1) {
			ShowRange(wNum);
			Debug.Log ("2nd weapon equipped");
			WeaponSelected=2;
			check = true;
		} else if (wNum == 2) {
			ShowRange(wNum);
			Debug.Log ("3rd weapon equipped");
			WeaponSelected=3;
			check = true;
		} else if (wNum == 3) {
			ShowRange(wNum);
			Debug.Log ("4th weapon equipped");
			WeaponSelected=4;
			check = true;
		}

		

	}

	void ShowRange(int rNum){

		for(int i =0;i<=3;i++)
		{
			WeaponRange[i].SetActive (false);
		}
		WeaponRange[rNum].SetActive (true);



	}

	void Deactivate(int Dnum){

		for(int i =0;i<=3;i++)
		{
			WeaponRange[i].SetActive (false);
		}
		deactivated = true;
	}

}
