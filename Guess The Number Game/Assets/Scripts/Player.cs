using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

	int health;
	int power;
	string name;

	public delegate void Score(string s);
	//public static event Score score;
	public static Score myScore;

	public Player (){
	}

	public Player (int health, int power, string name){
		this.health = health;
		this.power = power;
		this.name = name;
	}

	public void Info (){
		Debug.Log ("health: " + this.health + ", power: " + this.power + ", name: " + this.name);
	}

	public void Attack (){
		Debug.Log ("Player is attacking");
	}

	public void test(){
		if (myScore != null){
			myScore ("murat");
		}
	}
}
