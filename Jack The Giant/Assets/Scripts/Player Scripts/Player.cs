using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;


	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		PlayerMoveKeyboard ();
	}

	// How to move player on x axis with animation
	void PlayerMoveKeyboard(){
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		// When player moves to right side
		if (h > 0){
			if (vel < maxVelocity){
				forceX = speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			// How to start animation
			anim.SetBool ("Walk", true);
		}

		// When player moves to left side
		else if (h < 0){
			if (vel < maxVelocity){
				forceX = -speed;
			}

			// How to turn back the player with giving size
			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			// How to start animation
			anim.SetBool ("Walk", true);
		} 
		// When player stops
		else {
			// How to stop animation
			anim.SetBool ("Walk", false);
		}

		myBody.AddForce (new Vector2 (forceX, 0f));


	}
}
