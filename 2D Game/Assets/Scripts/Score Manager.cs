using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();

		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (score < 0)
			Score = 0;

			ScoreText.text = " " + Score;
	}
}
