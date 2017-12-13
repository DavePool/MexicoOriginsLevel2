﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {

	[SerializeField]
	private Transform startPos, endPos;

	private bool col;

	public float speed = 1f;

	private Rigidbody2D myBody;


	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move ();
		ChangeDirection ();
	}


	void ChangeDirection(){
		col = Physics2D.Linecast (startPos.position, endPos.position,1 << LayerMask.NameToLayer("Ground"));

		Debug.DrawLine (startPos.position, endPos.position, Color.green);

		if (!col) {
			Vector3 temp = transform.localScale;
			if (temp.x == 1f) {
				temp.x = -1f; 
			} else {
				temp.x = 1f;
			}

			transform.localScale = temp;
		}
	}

	void Move(){
		myBody.velocity = new Vector2 (transform.localScale.x, 0) *  speed;

	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			Destroy (target.gameObject);
		}
	}

}


































































