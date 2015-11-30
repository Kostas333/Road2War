using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text thetext;
	public TextAsset textfile;
	public string[] textLines;

	public int curLine;
	public int endAtLine;

	public bool isActive;
	public bool stopMovement=false;

	private bool isTyping=false;
	private bool cancelTyping=false;
	public float typeSpeed;
	// Use this for initialization
	void Awake(){
		isActive = true;
		StartCoroutine(Wait());
		textBox.SetActive(false); 
	}

	void Start () {

			if (textfile != null) {
			
				textLines = (textfile.text.Split ('\n'));
			
			


			if (endAtLine == 0) {
		
				endAtLine = textLines.Length - 1;


			}
		}
		enableTxtBx();
	}
	
	
	// Update is called once per frame
	void Update () {
		if (!isActive) {
			return;
		}
		//thetext.text = textLines [curLine];
//		if (curLine >= endAtLine) {
//			disableTxtBx();
//
//		}
	}

	public void nextPushed(){
		if (!isTyping) {
			curLine += 1;
			//thetext.text = textLines [curLine];
			if (curLine >= endAtLine) {
				disableTxtBx ();
				
			} else {
				StartCoroutine(TextScroll(textLines[curLine]));

			}
		
		} else if (isTyping && !cancelTyping) {
			cancelTyping=true;
		}

	}
	private IEnumerator TextScroll(string lineoftext){
	
		int letter = 0;
		thetext.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping&&!cancelTyping && (letter<lineoftext.Length-1)) {
			thetext.text +=lineoftext[letter];
			letter+=1;
			yield return new WaitForSeconds(typeSpeed);
		}
		thetext.text = lineoftext;
		isTyping = false;
		cancelTyping = false;
	}

	public void disableTxtBx(){

		textBox.SetActive(false);
		isActive = false;
		FSM.canmove = true;
	}

	public void enableTxtBx(){
		
		textBox.SetActive(true);
		isActive = true;

			FSM.canmove = false;
		StartCoroutine (TextScroll (textLines [curLine]));

	}

	public void reloadTxt(TextAsset thetext){


		if (thetext != null) {
		
			textLines=new string[1];
			textLines=(thetext.text.Split('\n'));
		}

	}
	IEnumerator Wait(){

		yield return new WaitForSeconds(1.5f);
		textBox.SetActive(true); 
		Debug.Log ("begin");
		
	}
}
