using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
		this.Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, (this.Player.transform.position - transform.position), out hit)){
			//print (hit.transform);
			if (hit.transform == this.Player.transform) {
				print ("Player Hit");
			} else {
				print ("Not player");
			}
		}
	}
}
