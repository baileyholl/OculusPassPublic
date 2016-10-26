using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
public class TextBehaviour : MonoBehaviour {

	private string passwordString = "";
	private string lastPassword = "";
	private bool lastReveal = true;

	// Update is called once per frame
	void Update () {
		if(!lastPassword.Equals(StaticVars.passwordText)||lastReveal!=StaticVars.reveal){
			lastPassword = StaticVars.passwordText;
			lastReveal = StaticVars.reveal;
			if (!StaticVars.reveal) {
				hideText ();
			} else {
				passwordString = StaticVars.passwordText;
			}
			gameObject.GetComponent<TextMesh> ().text = passwordString;
		}
	}

	public void hideText(){
		string pt = StaticVars.passwordText;
		passwordString = "";
		for (int i = 0; i < pt.Length; i++) {
			if (i != pt.Length - 1) {
				passwordString += "*";
			} else {
				passwordString += pt.Substring (i);
			}
		}
	}
}
