using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SCommon : MonoBehaviour {
	public GameObject[] popUpBoxes;	//0_BoxScore, 1_LightGreen, 2_LightRed, 3_BoxUserInput, 4_BoxTmpLeaderBoard, 5_BoxClearConfirm,
								//6_BoxGameOver, 7_BoxGamePaused, 8_BoxAbout, 9_LoadingScreen
	private GameObject gameManager;
	private Vector3 lightPosition;
	private Transform lightTmp;
	//public bool paused = false;
	public bool Restart;
	public int soundOn;
	public AudioSource[] audioList; //0_AudRightTap, 1_AudWrongTap, 2_AudGameOver, 3_AudSceneLoad, 
									//4_AudHallOfFame, 5_AudHomeScreen

	void Awake() {
		Restart = false;
		soundOn = PlayerPrefs.GetInt ("soundOn", 1);
	}
	void Start() {
		gameManager = GameObject.Find ("_GM");
		try {
			lightPosition = GameObject.Find ("LightYellow").transform.position;
		}
		catch (Exception e) {
			Debug.Log ("No 'LightYellow' object found!");
		}
		Debug.Log ("Sound " + soundOn);
	}

	public void ShowLight(int id) {
		lightTmp = Instantiate (popUpBoxes [id].transform);
		lightTmp.position = lightPosition;
	}
}
