using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal
{

	public override void eat ()
	{
		Debug.Log ("Horse eat no argument");
	}

	public void eat (string s)
	{
		Debug.Log ("Horse eats " + s);
	}


}
