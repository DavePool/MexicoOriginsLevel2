﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public Animator anim;
	
	private Queue<string> sentences;
	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	public void StartDialogue(Dialogue dialogue){

		anim.SetBool ("IsOpen", true);
		nameText.text = dialogue.name;

		sentences.Clear ();

		foreach (string sentence in dialogue.sencences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence(){
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSencence(sentence));
	}

	IEnumerator TypeSencence(string sencence){
		dialogueText.text = ""; 
		foreach (char letter in sencence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}

	}

	void EndDialogue(){
		anim.SetBool ("IsOpen", false);
	}

}
