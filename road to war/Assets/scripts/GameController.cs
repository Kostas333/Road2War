using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
//	public MoveToCursor Captain;
//	public MoveToCursor KungFu;
//	public MoveToCursor typical;
//
//	public MoveToCursor CaptainTouch;
//	public MoveToCursor KungFuTouch;
//	public MoveToCursor typicalTouch;
	public FSM Captain;
	public FSM KungFu;
	public FSM typical;
	
	public FSM CaptainTouch;
	public FSM KungFuTouch;
	public FSM typicalTouch;
	public static bool captainTrue;
	public static bool soldierTrue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void trooper()
	{
		KungFu.selectplayer();
		Captain.deselectplayer();
		typical.deselectplayer();


	}
	public void capatain()
	{
		captainTrue = true;
		//Time.timeScale = 1;
		Captain.selectplayer();
		KungFu.deselectplayer();
		typical.deselectplayer();
	}
	public void typicalplayer()
	{
		soldierTrue = true;
		typical.selectplayer();
		Captain.deselectplayer();
		KungFu.deselectplayer();
	}

	public void KungFuTouchMethod()
	{
		soldierTrue = true;
		KungFuTouch.selectplayer();
		CaptainTouch.deselectplayer();
		typicalTouch.deselectplayer();
		
		
	}
	public void capatainTouch()
	{
		CaptainTouch.selectplayer();
		KungFuTouch.deselectplayer();
		typicalTouch.deselectplayer();
	}
	public void typicalplayerTouch()
	{
		soldierTrue = true;
		typicalTouch.selectplayer();
		CaptainTouch.deselectplayer();
		KungFuTouch.deselectplayer();
	}
	public void trooperplayerTouch()
	{
		soldierTrue = true;
		typicalTouch.deselectplayer();
		CaptainTouch.deselectplayer();
		KungFuTouch.selectplayer();
	}
}
