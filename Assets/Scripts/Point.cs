using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Point : MonoBehaviour {
	private GameController gameState;
	public Vector3 rotationAxis = Vector3.forward;
	public float rotationPeriod = 1;

	// Use this for initialization
	void Awake () {
		gameState = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
	}

	void Update() {
		this.transform.Rotate (rotationAxis, Time.deltaTime / rotationPeriod * 360);
	}

	void OnTriggerEnter(Collider otherCollider) {
        GameObject other = otherCollider.gameObject;
		if (other.tag == "Player") {
            other.GetComponent<Player>().SetHappy(1f);
			gameState.points += 1;
			Destroy (this.gameObject);
		}
	}
}
