using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCloser : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (0);
		}
	}
}
