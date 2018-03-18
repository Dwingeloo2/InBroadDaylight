using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class PlayerKiller : MonoBehaviour {
	public bool kill = true;
	public float damagePerSpeed = 0;

	void Awake() {
		if (!kill && this.GetComponent<Collider> ().isTrigger) {
			Debug.LogError ("Cannot support damage with velocity for a trigger object");
		}
	}

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player != null) {
			if (kill) {
				player.Die ();
			} else {
				Debug.LogError ("Cannot support damage with velocity for a trigger object");
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		Player player = other.gameObject.GetComponent<Player>();
		if (player != null) {
			if (kill) {
				player.Die ();
			} else {
				player.AffectHealth (-damagePerSpeed * other.relativeVelocity.magnitude);
			}
		}
	}
}
