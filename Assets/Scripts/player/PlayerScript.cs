using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float moveForce = 20f, JumpForce = 700f, maxVelocity = 4f;

	private bool grounded;

	private Rigidbody2D myBody;
	private Animator anim;



	// Use this for initialization
	void Awake () {
		InicializateVariables ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerWalkKeyBoard ();
	}

	void InicializateVariables(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void PlayerWalkKeyBoard(){
		float forceX = 0f;
		float forceY = 0f;

		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0 ) {
			
			if (vel < maxVelocity) {
				if (grounded) {
					forceX = moveForce;	
				} else {
					forceX = moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool ("walk", true);
		}else if (h < 0) {
			if (vel < maxVelocity) {
				if (grounded) {
					forceX = -moveForce;	
				} else {
					forceX = -moveForce * 1.1f;
				}
			}
			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool ("walk",true);

		}else if (h == 0) {
			anim.SetBool ("walk", false);
		}

		if (Input.GetKey(KeyCode.Space)) {
			if (grounded) {
				grounded = false;
				forceY = JumpForce;
			}
		}

		myBody.AddForce (new Vector2(forceX,forceY));
	}

	public void BouncePlayerWithBouncy(float force){
		if (grounded) {
			grounded = false;
			myBody.AddForce (new Vector2(0,force));
		}
	}

	void OnCollisionEnter2D(Collision2D target){

		if (target.gameObject.tag == "Ground") {
			grounded = true;	
		}
	}

}




























