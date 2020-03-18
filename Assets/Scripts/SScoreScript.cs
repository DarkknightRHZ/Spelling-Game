using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SScoreScript : MonoBehaviour {

	public string playerName;
	public int score;
	public int maxScore, maxScore1, maxScore2, maxScore3;
	public float accuracy;
	public float maxAccuracy, maxAccuracy1, maxAccuracy2, maxAccuracy3;
	public int gameMode = 0;
	public int level;
	public int scoreCurrentLevel;
	public int timeBonus;
	private bool firstTime;
	private int count;

	void Start () {
		playerName = "";
		Reset ();
		//gameMode = 0;

	}


	public void AddScore(int sc, float ac, float tl) {
		scoreCurrentLevel = sc;
		timeBonus = ((int) tl) * 2;
		score += (sc + timeBonus);
		level++;
		if (firstTime == true) {
			accuracy = ac;
			firstTime = false;
		} else {
			accuracy = ((accuracy * ((float) count)) + ac) / ((float) (count + 1));
		}
		count++;
		//UpdateStat (score, accuracy);
	}

	public void SetPlayerName(string value) {
		playerName = value;
	}

	public void SetGameMode(int value) {
		gameMode = value;
	}

	public void UpdateStat(int sc = 0, float ac = 0f) {
		
		maxScore1 = PlayerPrefs.GetInt ("maxScore1", 0);
		maxScore2 = PlayerPrefs.GetInt ("maxScore2", 0);
		maxScore3 = PlayerPrefs.GetInt ("maxScore3", 0);

		if (score < maxScore3) {
			return;
		}
		for (gameMode = 1; gameMode <= 3; gameMode++) {

			string s1 = "maxScore" + gameMode;
			string s2 = "maxAccuracy" + gameMode;
			string s3 = "maxName" + gameMode;

			maxScore = PlayerPrefs.GetInt (s1, 1);
			maxAccuracy = PlayerPrefs.GetFloat (s2, 100f);
			string pn = PlayerPrefs.GetString (s3, "Anonymous");

			if (score > maxScore || (score == maxScore && (accuracy - maxAccuracy) > 0.001)) {
				int tScore = score, tScore1;
				float tAcc = accuracy, tAcc1;
				string tName = playerName, tName1;
				for (int i = gameMode; i <= 3; i++) {
					string tmp = "maxScore" + i;
					tScore1 = PlayerPrefs.GetInt (tmp, 0);
					PlayerPrefs.SetInt (tmp, tScore);
					tmp = "maxAccuracy" + i;
					tAcc1 = PlayerPrefs.GetFloat (tmp, 100f);
					PlayerPrefs.SetFloat (tmp, tAcc);
					tmp = "maxName" + i;
					tName1 = PlayerPrefs.GetString (tmp, "Anonymous");
					PlayerPrefs.SetString (tmp, tName);
					tName = tName1;
					tScore = tScore1;
					tAcc = tAcc1;
				}
				break;
			}
		}
		//maxScore = sc;
		//maxAccuracy = ac;
		//Debug.Log ("Stat Update! " + s1 + " = " + sc + " " + s2 + " = " + ac + " " + s3 + " " + playerName);
	}

	public void Reset() {
		score = 0;
		accuracy = 100f;
		firstTime = true;
		count = 0;
		level = 0;
		scoreCurrentLevel = 0;
		timeBonus = 0;
		string s1 = "maxScore" + gameMode;
		string s2 = "maxAccuracy" + gameMode;
		maxScore = PlayerPrefs.GetInt(s1, 0);
		maxAccuracy = PlayerPrefs.GetFloat (s2, 0f);
		Debug.Log ("maxScore " + maxScore + " maxAccuracy " + maxAccuracy);
	}
}
