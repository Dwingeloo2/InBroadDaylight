using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour {
	public GameObject sunPrefab;
	public GameObject planetPrefab;
	public int numPlanets;
	public float minDistance;
	public float maxDistance;
	public float minPlanetRadius;
	public float maxPlanetRadius;

	public int seed = 0x12345678;
	System.Random rand;

	void Awake() {
		rand = new System.Random (seed);
	}

	void Start() {
		GameObject sun = Instantiate (sunPrefab, this.transform);

		for (int i = 0; i < numPlanets; ++i) {
			float minD = (i + 0) * (maxDistance - minDistance) / numPlanets + minDistance;
			float maxD = (i + 1) * (maxDistance - minDistance) / numPlanets + minDistance;
			GeneratePlanet (sun.transform, minD, maxD, minPlanetRadius, maxPlanetRadius);
		}
	}

	GameObject GeneratePlanet (Transform center, float minD, float maxD, float minR, float maxR) {
		GameObject planet = Instantiate (planetPrefab, center);

		maxR = (maxD - minD) / 2;

		if (maxR < minR) {
			Debug.LogWarning ("Minimum radius will produce planet larger than distance range");
			maxR = minR;
		}

		float radius = (float)(rand.NextDouble () * (maxR - minR) + minR);
		planet.transform.localScale *= radius * 2;

		maxD -= radius;
		minD += radius;

		Orbiter orbiter = planet.GetComponent<Orbiter> ();
		orbiter.center = center;
		orbiter.ccw = rand.Next () % 2 == 0;
		orbiter.distance = (float)(rand.NextDouble () * (maxD - minD) + minD);
		orbiter.period = orbiter.distance;

		return planet;
	}
}
