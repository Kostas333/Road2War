using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {
	float speed = 20;
	float checkSpeed;
	Animator anim;
	public bool selected;
	enum Direction {FacingRight,FacingLeft,FacingUp,FacingDown};
	//enum Direction {FacingRight,FacingLeft,FacingUp,FacingDown};
	bool up,down,left,right;
	Direction mydirection = Direction.FacingDown;
	void Start () 
	{
		anim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(selected)
		{
		move ();
		}
	}
	 void move()
	{

		if(right)
		{
			MoveRightAction();
			transform.Translate (new Vector3 (speed*Time.deltaTime,0f,0f),Space.World);
			checkSpeed = speed*Time.deltaTime;
		}
		else if(left)
		{
			MoveLeftAction();
			transform.Translate (new Vector3(-speed*Time.deltaTime,0f,0f),Space.World);
			checkSpeed = speed*Time.deltaTime;
		}
		else if(up)
		{
			MoveUpAction();
			transform.Translate (new Vector3(0f,0f,speed*Time.deltaTime),Space.World);
			checkSpeed = speed*Time.deltaTime;
		}
		else if(down)
		{
			MoveDownAction();
			transform.Translate (new Vector3 (0f,0f,-speed*Time.deltaTime),Space.World);
			checkSpeed = speed*Time.deltaTime;
		}
		else
		{
			checkSpeed =0;
		}

		anim.SetFloat ("speed",Mathf.Abs (checkSpeed));
		
	}
	
	


public void upPressed()
{
		up = true;
}
	public void upReleased()
	{
		up = false;
	}
	public void downPressed()
	{
		down = true;
	}
	public void downReleased()
	{
		down = false;
	}
	public void leftPressed()
	{
		left = true;
	}
	public void leftReleased()
	{
		left = false;
	}
	public void rightPressed()
	{
		right = true;
	}
	public void rightRelease()
	{
		right = false;
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
	public void selectplayer()
	{
		selected = true;
	}
	public void deselectplayer()
	{
		selected = false;
	}
}
