using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SBoxCommon : MonoBehaviour {

	GameObject gameManager;

	void OnEnable() {
		Time.timeScale = 0;
		//Debug.Log ("Enabled");
	}

	void OnDisable() {
		Time.timeScale = 1;
		//Debug.Log ("Disabled");
	}
}
