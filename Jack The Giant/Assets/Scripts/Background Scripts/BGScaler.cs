using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// How to get sprite width
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float width = sr.sprite.bounds.size.x;

		// How to get worldHeight
		float worldHeight = Camera.main.orthographicSize * 2f;

		// How to get world width
		float worldWidth = worldHeight / Screen.height * Screen.width;

		// How to initialize sprite scale regarding to world and sprite width
		Vector3 tempScale = transform.localScale;
		tempScale.x = worldWidth / width;
		transform.localScale = tempScale;

	}

}
