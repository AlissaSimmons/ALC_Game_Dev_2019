using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){

		if(other.name == "Protagonist")
		{
		Debug.Log("Player Enters Death Zone");
		Destroy(other);
		}
	
	}
}
