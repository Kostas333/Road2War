using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoTypingText : MonoBehaviour {


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
		textnumber = 0;
		if (textnumber == 0) {
			x=0;
			y=0;
			z=0;
			e=0;
			w=0;
			a=0;
		}
		theText [0] = "Welcome";
		//theText [0] = "Welcome to Road To War...For our first mission lets learn how to control our player.";
		theText [1] = "Press the button shown to control your main character and go to the red arrow position, You can pick up weapons that you find by simply walking on them!..";
		theText [3] = "ons that you find by simply walking on them";
		theText [4] = "To equip your weapon, press the weapon icon on the left of your screen, In order to do so simply find targets with black halo, get in range and shoot them... Make sure you have equipped your weapon";
		theText [5] = "Your mission now is to find a way out of here and kill some more enemies";
		theText [6] = "Good job,now kill the enemies that have captivated your soldier";//....Seems that you are trapped in this camp. Press the button below captains to change player";
		//theText [7] = "Your soldier is fataly injured,find a way to free captain from the enemy camp before he dies.";//.There is a high possibility that there is a lever outside the camp door, better try looking for it";
		//theText [8] = "Well done, unfortunately your soldier died trying to save his captain!! Now you have 2 minutes to go west and free your other partner, or the enemies will kill him";
		StartCoroutine(TypeText(textnumber));
    }

	void Update(){

		if (FSM.endpick) {
			textnumber = 3;
			if(x==0){
			StartCoroutine(TypeText(textnumber));
				x++;}
		}
		if(ItemSelection.check)
		if(y==0){
			Debug.Log("sf");
			textnumber=5;
			StartCoroutine(TypeText(textnumber));
			y++;}

//		if (enemyScript1.kill) {
//			if(z==0){
//
//				textnumber=6;
//				StartCoroutine(TypeText(textnumber));
//				z++;}
//		}
		if (FSM.changeplayer) {
			if(e==0){
				
				textnumber=7;
				StartCoroutine(TypeText(textnumber));
				e++;}
		}
		if (Door.door) {
			if(w==0){
				
				textnumber=8;
				StartCoroutine(TypeText(textnumber));
				w++;}
		}

		if (enemyScript1.killcount==3)
			textToDisplay[6].enabled=false;
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
		if (i == 4) {

			
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
				
				yield return new WaitForSeconds (pauseTime);
				textnumber=5;
				
				//i=4;
			} 
			StartCoroutine(TypeText(textnumber));
		}
		if (i == 5) {
			
			textToDisplay[i].enabled=false;
			textToDisplay[i-1].enabled=false;
			//textToDisplay=null;
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
			
			//StartCoroutine(TypeText(textnumber));
		}

	if (i == 6) {
		
		
		textToDisplay[i-1].enabled=false;
		//textToDisplay=null;
		foreach (char letter in theText[i].ToCharArray()) {
			Debug.Log("ssdaf");
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
			//textnumber=7;
			
			//i=4;
		} 
		
			//StartCoroutine(TypeText(textnumber));
	}
		if (i == 7) {
			
			
			textToDisplay[i-1].enabled=false;
			//textToDisplay=null;
			foreach (char letter in theText[i].ToCharArray()) {
				Debug.Log("ssdaf");
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
				textnumber=8;
				
				//i=4;
			} 
			
			//StartCoroutine(TypeText(textnumber));
		}
		if (i == 8) {
			
			
			textToDisplay[i-1].enabled=false;
			//textToDisplay=null;
			foreach (char letter in theText[i].ToCharArray()) {
				Debug.Log("ssdaf");
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
				textnumber=8;
				
				//i=4;
			} 
			
			//StartCoroutine(TypeText(textnumber));
		}
	}}
