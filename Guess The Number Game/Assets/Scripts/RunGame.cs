using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGame : MonoBehaviour
{

	void Awake(){
		Player.myScore += somefunction;
		//Player.myScore ("murat");

		//Player.myScore -= somefunction;
		Player.myScore += otherfunction;
		//Player.myScore ("ece");
	}

	// Use this for initialization
	void Start ()
	{
//		Player player = new Player (10, 20, "Warrior");
//		player.Info ();

//		Animal a1 = new Animal ();
//		a1.eat (); // animal eat method
//
//		Horse a2 = new Horse ();
//		a2.eat (); // Horse eat no argument
//
//		Animal a3 = new Horse ();
//		a3.eat (); // Horse eat no argument
//
//		Horse a4 = new Horse ();
//		a4.eat ("carrot"); // animal eat method

//		Warrior war = new Warrior ();
//		war.Attack ();
//		war.Info ();

		Player player = new Player ();
		player.test ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void somefunction(string s){
		Debug.Log ("some functions " + s);
	}

	void otherfunction (string s){
		Debug.Log ("other functions " + s);
	}
}
