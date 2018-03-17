using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Point : MonoBehaviour {
	private GameState gameState;

	// Use this for initialization
	void Awake () {
		gameState = GameObject.FindWithTag ("GameController").GetComponent<GameState>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			gameState.points += 1;
			Destroy (this.gameObject);
		}
	}
}
