using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GuessTheNumberGame : MonoBehaviour {

	public InputField input;
	public Text infoText;

	private int guessNumber;
	private int userGuess;
	private int tryNumber;

	// Use this for initialization
	void Start () {

		tryNumber = 0;
		guessNumber = Random.Range(0,100);
		infoText.text = "Guess a number between 0 and 100";
		input.text = "";
		input.Select();
		Debug.Log("Guess number is: " + guessNumber);

		test(out firstParam, out secondParam);

		Debug.Log("first param = " + firstParam + ", second param = " + secondParam);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void checkGuess(){

		string inputText = input.text;
		int value;

		// String olan bir deger eger integer olarak parse edilebilecekse ediliyor.
		if(int.TryParse(inputText, out value)){
			userGuess = int.Parse(inputText);
		}
		else{
			userGuess = 0;
		}

		Debug.Log("User guess is: " + userGuess);
		print("This is a print");
		tryNumber += 1;

		if (guessNumber == userGuess){
			infoText.text = "Estimation is true at " + tryNumber + " times!";
			StartCoroutine(restartGame());
		} else if (userGuess > guessNumber){
			infoText.text = "Go lower";
		} else if (userGuess < guessNumber){
			infoText.text = "Go higher";
		}

		input.text = "";
		input.Select();
	}

	IEnumerator restartGame(){
		yield return new WaitForSeconds(0.5f);
		bool again = EditorUtility.DisplayDialog("Great!", "Would you like to play again?", "Yes", "No");
		if (again) Start();
	}

	int firstParam;
	int secondParam;

	// Bir variablein degeri fonksiyonda degistirilmek istenildiginde kullanilir.
	public void test(out int firstParam, out int secondParam){
		firstParam = 5;
		secondParam = 7;
	}
}
