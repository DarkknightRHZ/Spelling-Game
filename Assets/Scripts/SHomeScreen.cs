using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHomeScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GetComponent<SCommon> ().soundOn == 1) {
			GetComponent<SCommon> ().audioList [5].Play ();
		}
	}

}
