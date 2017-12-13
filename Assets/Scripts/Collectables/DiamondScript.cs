using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (DoorScrip.instance != null) {
			DoorScrip.instance.collectablesCount ++;
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Player") {
			Destroy (gameObject);
			if (DoorScrip.instance != null) {
				DoorScrip.instance.DecrementCollectables ();
			}
		}
	}


}
