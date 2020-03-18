using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STmpLeaderBoard : MonoBehaviour {

	public Text details;

	void OnEnable() {
		string playerName = PlayerPrefs.GetString ("maxName1", "Anonymous");
		int score = PlayerPrefs.GetInt ("maxScore1", 0);
		float accuracy = PlayerPrefs.GetFloat ("maxAccuracy1", 0f);
		details.text = playerName + "\nScore: "+ score + ";\tAccuracy: " + (int) accuracy + ";";
	}
}
