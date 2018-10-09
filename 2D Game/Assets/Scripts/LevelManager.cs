using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D Protagonist;

	// Particles
	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay
	public float RespawnDelay;

	// Point Penalty on Death
	public int PointPenaltyOnDeath;

	// Store Gravity Value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		// Protagonist = FindObjectOfType<Rigidbody2D> ();
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnProtagonistCo");
	}

	public IEnumerator RespawnProtagonistCo(){
		// Generate Death Particle
		Instantiate (DeathParticle, Protagonist.transform.position, Protagonist.transform.rotation);
		// Hide Protagonist
		// Protagonist.enabled = false;
		Protagonist.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = Protagonist.GetComponent<Rigidbody2D>().gravityScale;
		Protagonist.GetComponent<Rigidbody2D>().gravityScale = 0f;
		Protagonist.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		// Debug Message 
		Debug.Log ("Protagonist Respawn");
		// Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		// Gragity Restore
		Protagonist.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		// Match Protagonists transform position
		Protagonist.transform.position = CurrentCheckPoint.transform.position;
		// Show Protagonist
		// Protagonist.enabled = true;
		Protagonist.GetComponent<Renderer> ().enabled = true;
		// Spawn Protagonist
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}
