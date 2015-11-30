using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CountDown : MonoBehaviour 
{
	// For our timer we will use minutes and seconds
	//public GameObject text1;
	//public GameObject text2;
	public float Seconds = 59;
	public float Minutes = 0;
	public Text textTimer; 
	bool once = true;
	public static bool timesUp=false;



	void Update()
	{
		if (this.gameObject.name=="Text 1" && AutoTypingText.w == 1) {
			textTimer.enabled=true;
			StartCoroutine (wait10 ());
		}

		if (GameController.soldierTrue) {
			if(once){
			
			StartCoroutine (wait10 ());
			textTimer.enabled=true;

			}
		}

		// This is if statement checks how many seconds there are to decide what to do.
		// If there are more than 0 seconds it will continue to countdown.
		// If not then it will reset the amount of seconds to 59 and handle the minutes;
		// Handling the minutes is very similar to handling the seconds.
	
	}

	void SetTimer(){

		if(Seconds <= 0)
		{
			Seconds = 59;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				// This makes the guiText show the time as X:XX. ToString.("f0") formats it so there is no decimal place.
				textTimer.text= Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}
		
		// These lines will make sure the time is shown as X:XX and not X:XX.XXXXXX
		if(Mathf.Round(Seconds) <= 9)
		{
			textTimer.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}
		else
		{
			textTimer.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}
		if (Seconds == 0 && Minutes == 0)
			timesUp = true;
		if (this.gameObject.name=="Text" &&AutoTypingText.w ==1 ) {
			textTimer.enabled=false;
			timesUp=true;
			once=false;
		}
	}

	IEnumerator wait10(){
		yield return new WaitForSeconds(3f);
		SetTimer();
	}
}