using UnityEngine;
using System.Collections;

public class ActivateBoxDialog : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager txtBox;
	public bool destroyOnActivate;
	bool once=true;

	// Use this for initialization
	void Start () {
		txtBox = FindObjectOfType<TextBoxManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void onbuttonClicked(){
		if (once) {
			txtBox.reloadTxt (theText);
			txtBox.curLine = startLine;
			txtBox.endAtLine = endLine;
			txtBox.enableTxtBx ();
			once=false;
		}
	}
	void OnTriggerEnter(Collider col){
		
		if (col.gameObject.tag == "Player") {

			txtBox.reloadTxt(theText);
			txtBox.curLine=startLine;
			txtBox.endAtLine=endLine;
			txtBox.enableTxtBx();

			if(destroyOnActivate){

				Destroy(gameObject);
			}
		}
}
}