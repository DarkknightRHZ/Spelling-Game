using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGameOverBox : MonoBehaviour {

	private GameObject gameManager;
	public Text TxtGoodByeText;
	public Text TxtScore;

	void Awake() {
		gameManager = GameObject.Find ("_GM");
	}

	void OnEnable() {
		gameManager.GetComponent<SScoreScript> ().UpdateStat ();
		int score = gameManager.GetComponent<SScoreScript> ().score;
		int ac = (int)gameManager.GetComponent<SScoreScript> ().accuracy;
		int mxScore = gameManager.GetComponent<SScoreScript> ().maxScore;
		int mxAc = (int) gameManager.GetComponent<SScoreScript> ().maxAccuracy;
		if (ac >= mxAc && score >= mxScore) {
			//Debug.Log ("maxAccuracy " + mxAc + " mxScore " + mxScore);
			TxtGoodByeText.text = "Congratulations! You've beat the leaderboard.";
		} else {
			TxtGoodByeText.text = "Well played! Better luck next time.";
		}
		TxtScore.text = "Score: " + score + "\tAccuracy: " + ac + "%";
		//Debug.Log ("GameOverBox enabled");
		if (gameManager.GetComponent<SCommon> ().soundOn == 1) {
			Debug.Log ("SounOn");
			gameManager.GetComponent<SCommon> ().audioList [2].Play ();
		}
	}
}
