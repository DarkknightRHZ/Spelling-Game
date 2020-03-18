using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMode1 : MonoBehaviour {

	// Use this for initialization
	private Vector3[] positionList = new Vector3[26];
	public Transform[] bubbleList = new Transform[26];
	public Text TxtInput;
	public Text TxtTarget;
	public Text TxtScore;
	public Text TxtCounter;
	public Text TxtGameSpeed;
	private float shuffleInterval;
	private float shuffleIntervalInit;
	private float shuffleTime;
	private float shuffleAcceleration;
	private float gameTime;
	private string targetTxt, inputTxt;
	private int idx, score, hitCount;
	private bool gameOver;
	private float accuracy;
	bool reDeal = false;
	private GameObject gameManager;

 	void Start () {
		GetComponent<SInit> ().Init (1);
		InitPositionList ();
		ResetLevel ();
		PlayAgain ();
		gameManager = GameObject.Find ("_GM");
	}

	void FixedUpdate() {
		gameTime -= Time.deltaTime;
		TxtCounter.text = "" + (int)gameTime;
		if (gameTime <= 1f && gameOver == false) {
			gameOver = true;
			FinishDeal (0);
		}
		shuffleTime -= Time.deltaTime;
		if (shuffleTime <= 0f) {
			shuffleTime = shuffleInterval;
			Shuffle ();
		}
		if (reDeal == true) {
			reDeal = false;
			FinishDeal(1);
		}
		if (GetComponent<SCommon> ().Restart == true) {
			Debug.Log ("Restarting");
			GetComponent<SCommon> ().Restart = false;
			Restart ();
		}
	}

	// Update is called once per frame
	void Update () {
		TxtGameSpeed.text = "Game Speed: " + ((100 - ((int)((shuffleInterval / shuffleIntervalInit) * 100f))) + 100) +  "%";
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GetComponent<SCommon> ().popUpBoxes [7].SetActive (true);
		}
		/**
		if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Began) {
			Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
			RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
			if (hitInformation.collider != null) {
				//Debug.Log ("Got Input");
				GameObject touchedObject = hitInformation.transform.gameObject;
				//Debug.Log("Touched " + touchedObject.transform.name);
				if (touchedObject.tag == "Bubble" && GetComponent<SCommon>().paused == false) {
					//Debug.Log ("Bubble");
					hitCount++;
					Deal (touchedObject);
				}

			}
		}
		**/
		if (Input.GetMouseButtonDown(0)) {
			Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
			RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
			if (hitInformation.collider != null) {
				//Debug.Log ("Got Input");
				GameObject touchedObject = hitInformation.transform.gameObject;
				//Debug.Log("Touched " + touchedObject.transform.name);
				if (touchedObject.tag == "Bubble" && Time.timeScale == 1) {
					//Debug.Log ("Bubble");
					hitCount++;
					Deal (touchedObject);
				}

			}
		}

	}

	void Shuffle() {
		int rnd = Random.Range (0, positionList.Length - 1);
		Vector3 tmp;
		for (int i = 0; i < positionList.Length; i++) {
			tmp = positionList [i];
			positionList [i] = positionList [rnd];
			positionList [rnd] = tmp;
		}
		for (int i = 0; i < bubbleList.Length; i++) {
			bubbleList [i].position = positionList [i];
		}
	}
		
	void InitPositionList(){
		for (int i = 0; i < bubbleList.Length; i++) {
			positionList [i] = bubbleList [i].position;
		}
	}

	public void ResetLevel() {
		gameOver = false;
		shuffleIntervalInit = shuffleInterval = PlayerPrefs.GetFloat("shuffleInterval", 5f);
		shuffleTime = shuffleInterval;
		shuffleAcceleration = 0.50f;
		GetComponent<SScoreScript> ().Reset ();
		score = GetComponent<SScoreScript> ().score;
		accuracy = GetComponent<SScoreScript> ().accuracy;

	}

	public void PlayAgain() {
		idx = 0;
		hitCount = 0;
		targetTxt = GetComponent<SDictionary> ().GetAWord ();
		inputTxt = "";
		TxtTarget.text = targetTxt;
		TxtInput.text = inputTxt;
		gameTime = PlayerPrefs.GetFloat("levelDuration", 30f) + 1f;
		TxtCounter.text = ""+ (int)gameTime;
	}

	private void Deal(GameObject obj) {
		char ch = 'a';
		for (int i = 0; i < bubbleList.Length; i++) {
			if (bubbleList [i].name == obj.name) {
				ch = (char)(i + 'a');
			}
		}

		if (targetTxt [idx] == ch) {
			idx++;
			inputTxt += ch;
			TxtInput.text = inputTxt;
			GetComponent<SCommon> ().ShowLight (1);
			if (GetComponent<SCommon> ().soundOn == 1) {
				//Debug.Log ("SoundOn");
				GetComponent<SCommon> ().audioList [0].Play ();
			}
		} else {
			shuffleInterval = Mathf.Max (shuffleInterval - shuffleAcceleration, 1f);
			GetComponent<SCommon> ().ShowLight (2);
			if (GetComponent<SCommon> ().soundOn == 1) {
				//Debug.Log ("SoundOn");
				GetComponent<SCommon> ().audioList [1].Play ();
			}
		}

		if (idx >= targetTxt.Length) {
			float ac = (((float)targetTxt.Length) / ((float)hitCount)) * 100f;
			GetComponent<SScoreScript> ().AddScore (targetTxt.Length * 10, ac, gameTime);
			score = GetComponent<SScoreScript> ().score;
			accuracy = GetComponent<SScoreScript> ().accuracy;
			TxtScore.text = "Score: " + score + ";  Acc: " + (int) accuracy + "%;";
			GetComponent<SCommon> ().popUpBoxes [0].SetActive (true);
			reDeal = true;
		}
	}

	public void FinishDeal(int val) {
		//gameManager.GetComponent<SScoreScript> ().UpdateStat ();
		if (val == 0) {
			//GetComponent<SScoreScript> ().UpdateStat (score, accuracy);
			TxtScore.text = "Score: " + score + ";  Acc: " + (int) accuracy + "%;";
			//Application.LoadLevel (0);
			GetComponent<SCommon>().popUpBoxes[6].SetActive(true);
		} else {
			shuffleInterval = Mathf.Min (shuffleInterval + shuffleAcceleration, shuffleIntervalInit);
			//shuffleInterval -= (shuffleInterval * shuffleAcceleration);
			PlayAgain ();
		}
	}

	private void Restart() {
		ResetLevel ();
		PlayAgain ();
	}
}
