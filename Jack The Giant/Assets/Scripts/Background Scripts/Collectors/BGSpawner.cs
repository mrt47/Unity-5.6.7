using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour {

	private GameObject[] backgrounds ;

	private float lastYPosition;

	void Awake(){
		GetBackgroundsAndSetYPosition ();
	}

	void GetBackgroundsAndSetYPosition(){
		backgrounds = GameObject.FindGameObjectsWithTag ("Background");

		lastYPosition = backgrounds [0].transform.position.y;

		for (int i = 1; i < backgrounds.Length; i++){
			if (lastYPosition > backgrounds[i].transform.position.y){
				lastYPosition = backgrounds [i].transform.position.y;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Background"){
			if (target.gameObject.transform.position.y == lastYPosition){
				Vector3 temp = target.gameObject.transform.position;
				float height = ((BoxCollider2D)target).size.y;

				for (int i = 0; i < backgrounds.Length; i++){
					if (!backgrounds[i].activeInHierarchy){
						temp.y -= height;
						lastYPosition = temp.y;
						backgrounds [i].transform.position = temp;
						backgrounds [i].gameObject.SetActive (true);
						break;
					}
				}
				Debug.Log ("test");
			}
		}
	}
}
