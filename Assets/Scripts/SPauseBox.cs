using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPauseBox : MonoBehaviour {

	public GameObject gameManager;
	public Text txtScore;

	void Awake () {
		gameManager = GameObject.Find ("_GM");

	}

	void OnEnable() {
		int score = gameManager.GetComponent<SScoreScript> ().score;
		float acc = gameManager.GetComponent<SScoreScript> ().accuracy;
		txtScore.text = "Score: " + score + " \tAccuracy: " + (int) acc + "%";
	}

}
