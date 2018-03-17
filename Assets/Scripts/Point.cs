using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Point : MonoBehaviour {
	private GameController gameState;

	// Use this for initialization
	void Awake () {
		gameState = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			gameState.points += 1;
			Destroy (this.gameObject);
		}
	}
}
