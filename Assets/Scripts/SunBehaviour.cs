using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour {

	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit)){
			if (hit.transform == Player.transform) {
				print ("Player Hit");
			}
		}
	}
}
