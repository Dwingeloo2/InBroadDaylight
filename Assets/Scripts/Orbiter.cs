using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour {
	public float offset = 0;
	public float period = 1;
	public float distance = 1;
	public bool ccw = false;
	public Transform center;
	
	// Update is called once per frame
	void Update () {
		Vector2 position = (Vector2)(center.position) + distance * new Vector2 ((float)Math.Sin ((Time.time / period + offset) * Math.PI * 2), (float)Math.Cos ((Time.time / period + offset) * Math.PI * 2));
		position.x *= ccw ? -1 : 1;
		this.transform.position = position;
	}
}
