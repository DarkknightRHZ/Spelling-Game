using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SBoxScore : MonoBehaviour {
	public Text txtCurrentLevel;
	public Text txtCurrentScore;
	GameObject gameManager;

	void Awake() {
		gameManager = GameObject.Find ("_GM");
	}

	public void OnEnable() {
		//Debug.Log ("Enbled Score");

		int level = gameManager.GetComponent<SScoreScript> ().level;
		int sc = gameManager.GetComponent<SScoreScript> ().scoreCurrentLevel;
		int timeBonus = gameManager.GetComponent<SScoreScript> ().timeBonus;
		int total = gameManager.GetComponent<SScoreScript> ().score;
		int ac = (int) gameManager.GetComponent<SScoreScript> ().accuracy;
		int scc = total - sc - timeBonus;
		txtCurrentLevel.text = "You Have Completed" + "\nLevel " + level + "!";
		txtCurrentScore.text = "Score Obtained\t\t" + sc + "\nTime Bonus\t\t" + timeBonus + 
			"\nScore Carried\t\t" + scc +"\nTotal Score\t\t" + total + "\nAccuracy\t\t" + ac + "%";
	}
}
