using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	float speed = 10;
	float checkSpeed;
	Animator anim;
	enum Direction {FacingRight,FacingLeft,FacingUp,FacingDown};
	Direction mydirection = Direction.FacingDown;
	public bool selected = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
		speed = -speed;

	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(selected)
//		{
//		shootMachineGun();
//		shootAk47Gun();
//		shootPistolGun();
//		shootBattleRifleGun();
//		shootGernadeGun();
//		shootRPGGun();
//		if(Input.GetKey(KeyCode.RightArrow))
//		{
//			MoveRightAction();
//		transform.Translate (new Vector3 (-speed*Time.deltaTime,0f,0f),Space.World);
//			checkSpeed = speed*Time.deltaTime;
//		}
//		else if(Input.GetKey(KeyCode.LeftArrow))
//		{
//			MoveLeftAction();
//			transform.Translate (new Vector3(speed*Time.deltaTime,0f,0f),Space.World);
//			checkSpeed = speed*Time.deltaTime;
//		}
//		else if(Input.GetKey(KeyCode.UpArrow))
//		{
//			MoveUpAction();
//			transform.Translate (new Vector3(0f,0f,-speed*Time.deltaTime),Space.World);
//			checkSpeed = speed*Time.deltaTime;
//		}
//		else if(Input.GetKey(KeyCode.DownArrow))
//		{
//			MoveDownAction();
//			transform.Translate (new Vector3 (0f,0f,speed*Time.deltaTime),Space.World);
//			checkSpeed = speed*Time.deltaTime;
//		}
//		else
//		{
//			checkSpeed =0;
//		}
//
//		}
//
//	
//		anim.SetFloat ("speed",Mathf.Abs (checkSpeed));
		
	
	}
	void MoveRightAction()
	{
		if(mydirection == Direction.FacingDown)
		{
			transform.Rotate((Vector3.down * 90),Space.World);
		}
		if(mydirection == Direction.FacingLeft)
		{
			transform.Rotate((Vector3.down * 180),Space.World);
		}
		if(mydirection == Direction.FacingUp)
		{
			transform.Rotate((Vector3.down * -90),Space.World);
		}
		mydirection =Direction.FacingRight;
	}
	void MoveLeftAction()
	{
		if(mydirection == Direction.FacingDown)
		{
			transform.Rotate((Vector3.down * -90),Space.World);
		}
		if(mydirection == Direction.FacingRight)
		{
			transform.Rotate((Vector3.down * 180),Space.World);
		}
		if(mydirection == Direction.FacingUp)
		{
			transform.Rotate((Vector3.down * 90),Space.World);
		}
		mydirection =Direction.FacingLeft;
	}
	void MoveUpAction()
	{
		if(mydirection == Direction.FacingDown)
		{
			transform.Rotate((Vector3.down * 180),Space.World);
		}
		if(mydirection == Direction.FacingRight)
		{
			transform.Rotate((Vector3.down * 90),Space.World);
		}
		if(mydirection == Direction.FacingLeft)
		{
			transform.Rotate((Vector3.down * -90),Space.World);
		}
		mydirection =Direction.FacingUp;
	}
	void MoveDownAction()
	{
		if(mydirection == Direction.FacingUp)
		{
			transform.Rotate((Vector3.down * 180),Space.World);
		}
		if(mydirection == Direction.FacingRight)
		{
			transform.Rotate((Vector3.down * -90),Space.World);
		}
		if(mydirection == Direction.FacingLeft)
		{
			transform.Rotate((Vector3.down * 90),Space.World);
		}
		mydirection =Direction.FacingDown;
	}
	void shootMachineGun()
	{
		if(Input.GetKey(KeyCode.M))
		{
		anim.SetBool("isMachineGun",true);
		}
		else
		{
			anim.SetBool("isMachineGun",false);
		}
	}
	void shootPistolGun()
	{
		if(Input.GetKey(KeyCode.P))
		{
			anim.SetBool("isPistol",true);
		}
		else
		{
			anim.SetBool("isPistol",false);
		}
	}
	void shootAk47Gun()
	{
		if(Input.GetKey(KeyCode.A))
		{
			anim.SetBool("isAK47",true);
		}
		else
		{
			anim.SetBool("isAK47",false);
		}
	}
	void shootBattleRifleGun()
	{
		if(Input.GetKey(KeyCode.B))
		{
			anim.SetBool("isBatleRifle",true);
		}
		else
		{
			anim.SetBool("isBatleRifle",false);
		}
	}
	void shootGernadeGun()
	{
		if(Input.GetKey(KeyCode.G))
		{
			anim.SetBool("isGernade",true);
		}
		else
		{
			anim.SetBool("isGernade",false);
		}
	}
	void shootRPGGun()
	{
		if(Input.GetKey(KeyCode.R))
		{
			anim.SetBool("isRPG",true);
		}
		else
		{
			anim.SetBool("isRPG",false);
		}
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
