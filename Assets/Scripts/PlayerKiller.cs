using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class PlayerKiller : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player != null) {
			player.Die();
		}
	}
}
