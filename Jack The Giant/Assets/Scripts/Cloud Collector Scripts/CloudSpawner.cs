using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distanceBetweenClouds = 3f;

	private float minX, maxX;

	private float lastCloudPositionY;

	private float controlX;

	[SerializeField]
	private GameObject[] collectables;

	private GameObject player;



	void Awake () {
		SetMinAndMaxX ();
		CreateClouds ();

		player = GameObject.Find ("Player");
	}

	void Start(){
		PositionThePlayer ();
	}

	// How to set minimum and maximum horizontal points for the clouds
	void SetMinAndMaxX () {
		Vector3 temp = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		maxX = temp.x - 0.5f;
		minX = -temp.x + 0.5f;
	}

	void Shuffle (GameObject [] arrayToShuffle){
		for (int i = 0; i < arrayToShuffle.Length; i++) {
			GameObject temp = arrayToShuffle [i];
			int random = Random.Range (i, arrayToShuffle.Length);
			arrayToShuffle [i] = arrayToShuffle [random];
			arrayToShuffle [random] = temp;
		}
	}

	void CreateClouds(){
		Shuffle (clouds);

		float positionY = 0f;
		controlX = 0f;

		for (int i = 0; i < clouds.Length; i++){
			Vector3 temp = clouds [i].transform.position;
			temp.y = positionY;

			if (controlX == 0f){
				temp.x = Random.Range (0.0f, maxX);
				controlX = 1f;
			} else if (controlX == 1f){
				temp.x = Random.Range (0.0f, minX);
				controlX = 2f;
			} else if (controlX == 2f){
				temp.x = Random.Range (1.0f, maxX);
				controlX = 3f;
			} else if (controlX == 3f){
				temp.x = Random.Range (-1.0f, minX);
				controlX = 0f;
			}

			lastCloudPositionY = positionY;

			clouds [i].transform.position = temp;

			positionY -= distanceBetweenClouds;

		}
	}

	void PositionThePlayer(){
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		for (int i = 0; i < darkClouds.Length; i++){
			Vector3 temp = darkClouds [i].transform.position;

			if (temp.y == 0f){
				darkClouds [i].transform.position = new Vector3 (
					cloudsInGame [0].transform.position.x,
					cloudsInGame [0].transform.position.y,
					cloudsInGame [0].transform.position.z);
				
				cloudsInGame [0].transform.position = temp;
			}
		} // swap darkCloud with white cloud if dark cloud is the first cloud

		Vector3 temp1 = cloudsInGame[0].transform.position;

		for (int i = 1; i < cloudsInGame.Length; i++){
			if (temp1.y < cloudsInGame[i].transform.position.y){
				temp1 = cloudsInGame [i].transform.position;
			}
		} // position the player on the first cloud
			
		temp1.y += 0.8f;
		player.transform.position = temp1;

	}

	// spawning new clouds
	void OnTriggerEnter2D (Collider2D target){
		if (target.tag == "Cloud" || target.tag == "Deadly"){
			if (target.transform.position.y == lastCloudPositionY){
				Shuffle (clouds);
				Shuffle (collectables);

				Vector3 temp = target.transform.position;

				for (int i = 0; i < clouds.Length; i++){
					if (!clouds[i].activeInHierarchy){
						if (controlX == 0f){
							temp.x = Random.Range (0.0f, maxX);
							controlX = 1f;
						} else if (controlX == 1f){
							temp.x = Random.Range (0.0f, minX);
							controlX = 2f;
						} else if (controlX == 2f){
							temp.x = Random.Range (1.0f, maxX);
							controlX = 3f;
						} else if (controlX == 3f){
							temp.x = Random.Range (-1.0f, minX);
							controlX = 0f;
						}

						temp.y -= distanceBetweenClouds;
						lastCloudPositionY = temp.y;
						clouds [i].transform.position = temp;
						clouds [i].SetActive (true);
					}
				}
			}
		}
	}
}
