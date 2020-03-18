using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDictionary : MonoBehaviour {

	// Use this for initialization
	public string[] WordList;

	public string GetAWord() {
		int id = Random.Range (0, WordList.Length - 1);
		return WordList [id];
	}

	public string GetAWord(int id) {
		return WordList [id];
	}
}
