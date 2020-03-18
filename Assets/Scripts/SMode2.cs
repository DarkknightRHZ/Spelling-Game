using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMode2 : MonoBehaviour {

	// Use this for initialization
	public Transform[] bubbleList = new Transform[26];
	public Transform[] bubbleInit = new Transform[2];
	public Text TxtInput;
	public Text TxtTarget;
	public Text TxtScore;
	public Text TxtCounter;
	public Text TxtGameSpeed;
	private float gameTime;
	private string targetTxt, inputTxt;
	private int idx, score, hitCount;
	private bool gameOver;
	private float accuracy;
	bool reDeal = false;
	public float spawnRate, xVelocity, yVelocity;
	public float xLeftLimit, xRightLimit, yTopLimit;

	void Awake() {
		xLeftLimit = bubbleInit [0].position.x;
		xRightLimit = bubbleInit [1].position.x;
		yTopLimit = bubbleInit [0].position.y;
	}

 	void Start () {
		GetComponent<SInit> ().Init (1);
		ResetLevel ();
		PlayAgain ();
	}

	void FixedUpdate() {
		gameTime -= Time.deltaTime;
		TxtCounter.text = "" + (int)gameTime;
		if (gameTime <= 1f && gameOver == false) {
			gameOver = true;
			FinishDeal (0);
		}

		if (reDeal == true) {
			reDeal = false;
			FinishDeal(1);
		}
		if (GetComponent<SCommon> ().Restart == true) {
			//Debug.Log ("Restarting");
			GetComponent<SCommon> ().Restart = false;
			Restart ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GetComponent<SCommon> ().popUpBoxes [7].SetActive (true);
		}
	
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

	public void ResetLevel() {
		gameOver = false;
		GetComponent<SScoreScript> ().Reset ();
		score = GetComponent<SScoreScript> ().score;
		accuracy = GetComponent<SScoreScript> ().accuracy;
		xVelocity = 0f;
		yVelocity = -2f;
		spawnRate = 0.5f;
	}

	public void PlayAgain() {
		idx = 0;
		hitCount = 0;
		targetTxt = GetComponent<SDictionary> ().GetAWord ();
		inputTxt = "";
		TxtTarget.text = targetTxt;
		TxtInput.text = inputTxt;
		gameTime = 31f;
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
		} else {
			GetComponent<SCommon> ().ShowLight (2);
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

	private void FinishDeal(int val) {
		if (val == 0) {
			GetComponent<SScoreScript> ().UpdateStat (score, accuracy);
			TxtScore.text = "Score: " + score + ";  Acc: " + (int) accuracy + "%;";
			//Application.LoadLevel (0);
			GetComponent<SCommon>().popUpBoxes[6].SetActive(true);
		} else {
			PlayAgain ();
		}
	}

	private void Restart() {
		ResetLevel ();
		PlayAgain ();
	}
}
