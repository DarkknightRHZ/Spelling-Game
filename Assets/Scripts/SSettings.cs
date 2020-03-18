using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSettings : MonoBehaviour {

	// Use this for initialization

	public float levelDuration;
	public float shuffleInterval;
	public int soundOn;
	public InputField inputLevelDuration;
	public InputField inputShuffleInterval;
	public Text txtSound;

	void Start () {
		levelDuration = PlayerPrefs.GetFloat ("levelDuration", 30f);
		shuffleInterval = PlayerPrefs.GetFloat ("shuffleInterval", 5f);
		soundOn = PlayerPrefs.GetInt ("soundOn", 1);
		inputLevelDuration.text = "" + levelDuration;
		inputShuffleInterval.text = "" + shuffleInterval;
		if (soundOn == 1) {
			txtSound.text = "On";
		} else {
			txtSound.text = "Off";
		}
	}
}
