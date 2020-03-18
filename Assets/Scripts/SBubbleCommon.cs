using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBubbleCommon : MonoBehaviour {

	private float xVelocity = 0f;
	private float yVelocity = -2f;
	private Vector2 velocity;
	private GameObject gameManager;

	void Awake() {
		gameManager = GameObject.Find ("_GM");
	}

	void Start() {
		velocity.x = xVelocity;
		velocity.y = yVelocity;
		GetComponent<Rigidbody2D> ().velocity = velocity; 
	}

	void FixedUpdate() {
		
	}

	void Update() {
		Destroy (gameObject, 60);
	}
}
