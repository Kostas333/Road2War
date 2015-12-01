using UnityEngine;
using System.Collections;

public class followTarget : MonoBehaviour {

	public GameObject cameraTarget;
	public GameObject cameraTarget2;// object to look at or follow
	public GameObject cameraTarget3;
//	// keboard controls script
//	public playerScript player1;
//	public playerScript player2;
//	public playerScript player3;

	//touch controls
//	public MoveToCursor player1;
//	public MoveToCursor	player2;
//	public MoveToCursor player3;
	public FSM player1;
	public FSM player2;
	public FSM player3;

	float smoothTime = 0.1f;    // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable
	public Vector3 velocity; // speed of camera movement

	
	private Transform thisTransform; // camera Transform
	
	// Use this for initialization
	void Start()
	{
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(player1.selected)
		{
		followTarget1();
		}
		if(player2.selected)
		{
		followTarget2();
		}
		if(player3.selected)
		{
		followTarget3();
		}
//		if(player1Touch.selected)
//		{
//			followTarget1();
//		}
//		if(player2Touch.selected)
//		{
//			followTarget2();
//		}
//		if(player3Touch.selected)
//		{
//			followTarget3();
//		}
	}
	void followTarget1()
	{
		if (cameraFollowX)
			
		{
			thisTransform.transform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime), thisTransform.position.y, thisTransform.position.z);
		}
		
		
		if (cameraFollowY)
		{
			thisTransform.transform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, Mathf.SmoothDamp(thisTransform.position.z, cameraTarget.transform.position.z-20, ref velocity.z, smoothTime));
		}
		if (!cameraFollowX & cameraFollowHeight)
		{
			// to do
		}
	}
	void followTarget2()
	{
		if (cameraFollowX)
			
		{
			thisTransform.transform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, cameraTarget2.transform.position.x, ref velocity.x, smoothTime), thisTransform.position.y, thisTransform.position.z);
		}
		
		
		if (cameraFollowY)
		{
			thisTransform.transform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, Mathf.SmoothDamp(thisTransform.position.z, cameraTarget2.transform.position.z-20, ref velocity.z, smoothTime));
		}
		if (!cameraFollowX & cameraFollowHeight)
		{
			// to do
		}

	}
	void followTarget3()
	{
		if (cameraFollowX)
			
		{
			thisTransform.transform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, cameraTarget3.transform.position.x, ref velocity.x, smoothTime), thisTransform.position.y, thisTransform.position.z);
		}
		
		
		if (cameraFollowY)
		{
			thisTransform.transform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, Mathf.SmoothDamp(thisTransform.position.z, cameraTarget3.transform.position.z-20, ref velocity.z, smoothTime));
		}
		if (!cameraFollowX & cameraFollowHeight)
		{
			// to do
		}

	}
}
