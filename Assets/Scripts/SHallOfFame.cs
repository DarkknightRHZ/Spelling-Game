using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHallOfFame : MonoBehaviour {

	public Text[] nameBoxes;
	public Text[] detailBoxes;

	void Start () {
		for (int i = 1; i <= 3; i++) {
			string nm = "maxName" + i;
			string sc = "maxScore" + i;
			string ac = "maxAccuracy" + i;
			nameBoxes [i-1].text = PlayerPrefs.GetString (nm, "Anonymous");
			detailBoxes [i-1].text = "Score: " + PlayerPrefs.GetInt (sc, 0) + ";\t" + "Accuracy: " + (int)PlayerPrefs.GetFloat (ac, 0f) + "%;";
		}
		if (GetComponent<SCommon> ().soundOn == 1) {
			GetComponent<SCommon> ().audioList [4].Play ();
		}
	}

	public void Reset() {
		for (int i = 1; i <= 3; i++) {
			string nm = "maxName" + i;
			string sc = "maxScore" + i;
			string ac = "maxAccuracy" + i;
			PlayerPrefs.SetString (nm, "Anonymous");
			PlayerPrefs.SetInt (sc, 0);
			PlayerPrefs.SetFloat (ac, 0f);
		}
		for (int i = 1; i <= 3; i++) {
			string nm = "maxName" + i;
			string sc = "maxScore" + i;
			string ac = "maxAccuracy" + i;
			nameBoxes [i-1].text = PlayerPrefs.GetString (nm, "Anonymous");
			detailBoxes [i-1].text = "Score: " + PlayerPrefs.GetInt (sc, 0) + ";\t" + "Accuracy: " + (int)PlayerPrefs.GetFloat (ac, 0f) + "%;";
		}
	}
}
