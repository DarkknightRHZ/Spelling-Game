using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SInit : MonoBehaviour {

	public Transform[] Backgrounds;

	public void Init(int gameMode) {
		GetComponent<SCommon> ().popUpBoxes [3].SetActive (true);
		GetComponent<SScoreScript> ().gameMode = gameMode;
	}
}
