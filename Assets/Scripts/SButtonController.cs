using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SButtonController : MonoBehaviour {

	private GameObject gameManager;
	public InputField inputName;

	void Start() {
		gameManager = GameObject.Find ("_GM");
	}

	void Update() {
		
	}

	public void LoadScene(int id) {
		gameManager.GetComponent<SCommon> ().popUpBoxes [9].SetActive (true);
		Application.LoadLevel (id);
	}

	public void Quit() {
		Application.Quit ();
	}

	public void Disable() {
		gameObject.SetActive (false);
	}
		
	public void TakeInputName() {
		string playerName = inputName.text;
		gameManager.GetComponent<SScoreScript> ().playerName = playerName;
		Disable ();
	}

	public void TmpShowStat () {
		gameManager.GetComponent<SCommon> ().popUpBoxes [4].SetActive (true);
	}

	public void ShowBox(int id) {
		gameManager.GetComponent<SCommon> ().popUpBoxes [id].SetActive (true);
	}

	public void ResetLeaderBoard() {
		gameManager.GetComponent<SHallOfFame> ().Reset ();
	}

	public void RestartLevel() {
		gameManager.GetComponent<SCommon> ().Restart = true;
		Disable ();
	}

	public void ShowAbout() {
		gameManager.GetComponent<SCommon> ().popUpBoxes [8].SetActive (true);
	}

	public void ToggleSoundButton () {
		gameManager.GetComponent<SSettings> ().soundOn ^= 1;
		if (gameManager.GetComponent<SSettings> ().soundOn == 1) {
			gameManager.GetComponent<SSettings> ().txtSound.text = "On";
		} else {
			gameManager.GetComponent<SSettings> ().txtSound.text = "Off";
		}
	}
		
	public void SetSettings () {
		string s = gameManager.GetComponent<SSettings> ().inputLevelDuration.text;
		PlayerPrefs.SetFloat("levelDuration", gameManager.GetComponent<SSettings> ().levelDuration = float.Parse (s));
		s = gameManager.GetComponent<SSettings> ().inputShuffleInterval.text;
		PlayerPrefs.SetFloat ("shuffleInterval", gameManager.GetComponent<SSettings> ().shuffleInterval = float.Parse (s));
		PlayerPrefs.SetInt ("soundOn", gameManager.GetComponent<SSettings> ().soundOn);
	}

	public void GameOver() {
		gameManager.GetComponent<SMode1> ().FinishDeal (0);
		gameObject.SetActive (false);
	}
}
