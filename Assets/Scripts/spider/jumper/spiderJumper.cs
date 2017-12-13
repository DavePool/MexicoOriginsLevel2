using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderJumper : MonoBehaviour {

	public float forceY = 300f;

	private Rigidbody2D myBody;
	private Animator anim;


	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Start () {
		StartCoroutine (Attack());
	}

	IEnumerator	Attack (){

		yield return new WaitForSeconds (Random.Range(2,7));

		forceY = Random.Range (200,550);
		myBody.AddForce (new Vector2(0,forceY));
		anim.SetBool ("Attack", true);

		yield return new WaitForSeconds (.7f);
		StartCoroutine (Attack());
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Ground") {
			anim.SetBool ("Attack", false);
		}

		if (target.tag == "Player") {
			Destroy (target.gameObject);
			Destroy (gameObject);
		}

	}

}









































































