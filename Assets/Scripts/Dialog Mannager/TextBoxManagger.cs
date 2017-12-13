using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManagger : MonoBehaviour {

	public GameObject TextBox;

	public Text theText;


	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtline;

	public PlayerScript player; 


	// Use this for initialization
	void Start () {
		
		player = FindObjectOfType<PlayerScript> ();

		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		if (endAtline == 0) {
			endAtline = textLines.Length - 1;
		}
	}

	void Update(){
		
		theText.text = textLines [currentLine];
		if (Input.GetKeyDown(KeyCode.Return)) {
			currentLine += 1;
		}

		if (currentLine > endAtline) {
			TextBox.SetActive (false);
		}
	}
}





























