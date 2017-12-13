using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class history : MonoBehaviour {

	[SerializeField]
	private GameObject TextPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			Destroy (gameObject);
			TextPanel.SetActive (true);
		}
	}
}
