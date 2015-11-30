using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class type2 : MonoBehaviour {

	public Text[] textToDisplay; //Display the text
	public string[] theText;
	//	public string theText2 = "Enter Text Here";
	//	public string theText3 = "Enter Text Here";
	//	public string theText4 = "Enter Text Here";
	//	public string theText5 = "Enter Text Here";
	public float minPause = 0.01f; //The higher the values the slower...
	public float maxPause = 0.1f; //...the typing will be
	public float fullStopPauseTime = 1f; //How long should we pause after a full stop?
	public float startDelay = 1f; //Add a start delay?
	public bool playSound = true; //Play a sound or silent?
	public AudioSource letterSound;
	public float minPitch = 1f; //Pitch of the...
	public float maxPitch = 1f; //...audiosource
	public static int textnumber=0;
	private float pauseTime;
	int a =0;
	int x=0;
	int y=0;
	int z=0;
	public static int e=0;
	public static int w=0;
	int i;
	void Start() {
		theText [0] = "Your mission now is to find a way to free your captain from this camp";
		//theText [0] = "Welcome to Road To War...For our first mission lets learn how to control our player.";
		theText [1] = "Press the button shown to control your second character, but careful you have only 1 minute, because he is fataly injured ";

		theText [3] = "Your soldier is fataly injured,find a way to free captain from the enemy camp before he dies.";//.There is a high possibility that there is a lever outside the camp door, better try looking for it";
		//theText [8] = "Well done, unfortunately your soldier died trying to save his captain!! Now you have 2 minutes to go west and free your other partner, or the enemies will kill him";
		StartCoroutine(TypeText(textnumber));
	}
	
	void Update(){
		

		if (FSM.changeplayer) {
			if (e == 0) {
				
				textnumber = 7;
				//StartCoroutine(TypeText(textnumber));
				e++;
			}
		}


		if (Door.door||Parol.GameOver||CountDown.timesUp) {
			textToDisplay[1].enabled=false;}
	}
	
	
	IEnumerator TypeText(int i) {
		if (startDelay > 0) {
			yield return new WaitForSeconds (startDelay);
		}
		if (i == 0) {
			foreach (char letter in theText[i].ToCharArray()) {
				textToDisplay[i].text += letter;
				if (playSound) { 
					letterSound.pitch = Random.Range (minPitch, maxPitch);
					letterSound.Play ();
					yield return 0;
				}
				if (letter.ToString () == ".") { 
					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
				} else {
					pauseTime = Random.Range (minPause, maxPause);
				}
				textnumber = 1;
				
				yield return new WaitForSeconds (pauseTime);
				
			} 
			StartCoroutine(TypeText(textnumber));
		}
		if (i == 1) {
			
			textToDisplay[i-1].enabled=false;
			//textToDisplay=null;
			foreach (char letter in theText[i].ToCharArray()) {
				textToDisplay[i].text += letter;
				if (playSound) { 
					letterSound.pitch = Random.Range (minPitch, maxPitch);
					letterSound.Play ();
					yield return 0;
				}
				if (letter.ToString () == ".") { 
					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
				} else {
					pauseTime = Random.Range (minPause, maxPause);
				}
				if(a==0){
					textnumber = 2;
					a++;
				}
				yield return new WaitForSeconds (pauseTime);
			
			} 
			
		}
		if (i == 3) {
			FSM.endpick=false;
			
			textToDisplay[i-2].enabled=false;
			//textToDisplay=null;
			foreach (char letter in theText[i].ToCharArray()) {
				textToDisplay[i].text += letter;
				if (playSound) { 
					letterSound.pitch = Random.Range (minPitch, maxPitch);
					letterSound.Play ();
					yield return 0;
				}
				if (letter.ToString () == ".") { 
					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
				} else {
					pauseTime = Random.Range (minPause, maxPause);
				}
				
				yield return new WaitForSeconds (pauseTime);

				textnumber=4;
				
				//i=4;
			} 
			
			StartCoroutine(TypeText(textnumber));
		}
//		if (i == 4) {
//			
//			
//			textToDisplay[i-1].enabled=false;
//			//textToDisplay=null;
//			foreach (char letter in theText[i].ToCharArray()) {
//				
//				textToDisplay[i].text += letter;
//				if (playSound) { 
//					letterSound.pitch = Random.Range (minPitch, maxPitch);
//					letterSound.Play ();
//					yield return 0;
//				}
//				if (letter.ToString () == ".") { 
//					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
//				} else {
//					pauseTime = Random.Range (minPause, maxPause);
//				}
//				
//				yield return new WaitForSeconds (pauseTime);
//				textnumber=5;
//				
//				//i=4;
//			} 
//			
//		}
//		if (i == 5) {
//			
//			
//			textToDisplay[6].enabled=false;
//			//textToDisplay=null;
//			foreach (char letter in theText[i].ToCharArray()) {
//				Debug.Log("ssdaf");
//				textToDisplay[i].text += letter;
//				if (playSound) { 
//					letterSound.pitch = Random.Range (minPitch, maxPitch);
//					letterSound.Play ();
//					yield return 0;
//				}
//				if (letter.ToString () == ".") { 
//					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
//				} else {
//					pauseTime = Random.Range (minPause, maxPause);
//				}
//				
//				yield return new WaitForSeconds (pauseTime);
//				//textnumber=6;
//				
//				//i=4;
//			} 
//			
//			//StartCoroutine(TypeText(textnumber));
//		}
//		
//		if (i == 6) {
//			
//			
//			textToDisplay[i-1].enabled=false;
//			//textToDisplay=null;
//			foreach (char letter in theText[i].ToCharArray()) {
//				Debug.Log("ssdaf");
//				textToDisplay[i].text += letter;
//				if (playSound) { 
//					letterSound.pitch = Random.Range (minPitch, maxPitch);
//					letterSound.Play ();
//					yield return 0;
//				}
//				if (letter.ToString () == ".") { 
//					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
//				} else {
//					pauseTime = Random.Range (minPause, maxPause);
//				}
//				
//				yield return new WaitForSeconds (pauseTime);
//				textnumber=7;
//				
//				//i=4;
//			} 
//			
//			//StartCoroutine(TypeText(textnumber));
//		}
//		if (i == 7) {
//			
//			
////			textToDisplay[i-1].enabled=false;
//			//textToDisplay=null;
//			foreach (char letter in theText[i].ToCharArray()) {
//				Debug.Log("ssdaf");
//				textToDisplay[i].text += letter;
//				if (playSound) { 
//					letterSound.pitch = Random.Range (minPitch, maxPitch);
//					letterSound.Play ();
//					yield return 0;
//				}
//				if (letter.ToString () == ".") { 
//					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
//				} else {
//					pauseTime = Random.Range (minPause, maxPause);
//				}
//				
//				yield return new WaitForSeconds (pauseTime);
//				textnumber=8;
//				
//				//i=4;
//			} 
//			
//			//StartCoroutine(TypeText(textnumber));
//		}
//		if (i == 8) {
//			
//			
//			textToDisplay[i-1].enabled=false;
//			//textToDisplay=null;
//			foreach (char letter in theText[i].ToCharArray()) {
//				Debug.Log("ssdaf");
//				textToDisplay[i].text += letter;
//				if (playSound) { 
//					letterSound.pitch = Random.Range (minPitch, maxPitch);
//					letterSound.Play ();
//					yield return 0;
//				}
//				if (letter.ToString () == ".") { 
//					pauseTime = Random.Range (minPause, maxPause) + fullStopPauseTime;
//				} else {
//					pauseTime = Random.Range (minPause, maxPause);
//				}
//				
//				yield return new WaitForSeconds (pauseTime);
//				textnumber=8;
//				
//				//i=4;
//			} 
//			
//			//StartCoroutine(TypeText(textnumber));
//		}
//	}}
	}}
