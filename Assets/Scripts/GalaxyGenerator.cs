using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour {
	public GameObject sunPrefab;
	public GameObject planetPrefab;
	public int numPlanets;
	public float minDistance;
	public float maxDistance;

	public int seed = 0x12345678;
	System.Random rand;

	void Awake() {
		rand = new System.Random (seed);
	}

	void Start() {
		GameObject sun = Instantiate (sunPrefab, this.transform);

		for (int i = 0; i < numPlanets; ++i) {
			Orbiter orbiter = Instantiate (planetPrefab, sun.transform).GetComponent<Orbiter>();
			orbiter.center = sun.transform;
			orbiter.ccw = rand.Next () % 2 == 0;
			orbiter.distance = (float)(rand.NextDouble () * (maxDistance - minDistance) + minDistance);
			orbiter.period = orbiter.distance;
		}
	}
}
