using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour {
	public GameObject sunPrefab;
	public GameObject planetPrefab;
	public GameObject pointPrefab;
	public int numPlanets = 1;
	public int numPoints = 1;
	public float minDistance = 1f;
	public float maxDistance = 2f;
	public float minPlanetRadius = 1f;
	public float maxPlanetRadius = 2f;
	public float minSpinPeriod = 1;
	public float maxSpinPeriod = 2;

	public float orbitalPeriodConstant = 1.0f;

	public int seed = 0x12345678;
	System.Random rand;

	void Awake() {
		rand = new System.Random (seed);
	}

	void Start() {
		GameObject sun = Instantiate (sunPrefab, this.transform);

		// generate planets
		for (int i = 0; i < numPlanets; ++i) {
			float minD = (i + 0) * (maxDistance - minDistance) / numPlanets + minDistance;
			float maxD = (i + 1) * (maxDistance - minDistance) / numPlanets + minDistance;

			// generate planet
			GeneratePlanet (sun.transform, minD, maxD, minPlanetRadius, maxPlanetRadius, minSpinPeriod, maxSpinPeriod);
		}

		// randomly shuffle pie sections of the galaxy
		IEnumerable<int> pieIsEnumerable = Enumerable.Range (0, numPoints);
		int[] pieIs = pieIsEnumerable.OrderBy(x => rand.Next()).ToArray();
		for (int i = 0; i < numPoints; ++i) {
			int pieI = pieIs [i];
			float minD = (i + 0) * (maxDistance - minDistance) / numPoints + minDistance;
			float maxD = (i + 1) * (maxDistance - minDistance) / numPoints + minDistance;
			float minDeg = (pieI + 0) * (360 - 0) / numPoints + 0;
			float maxDeg = (pieI + 1) * (360 - 0) / numPoints + 0;

			// generate point
			GeneratePoint (sun.transform, minD, maxD, minDeg, maxDeg);
		}
	}

	GameObject GeneratePoint (Transform center, float minD, float maxD, float minDeg, float maxDeg) {
		float angle = (float)(rand.NextDouble () * (maxDeg - minDeg) + minDeg);
		Vector3 localPosition = (float)(minD + rand.NextDouble () * (maxD - minD)) * (Quaternion.Euler (0, 0, angle) * Vector3.up);

		GameObject point = Instantiate (pointPrefab, this.gameObject.transform);
		point.transform.localPosition = localPosition;

		Point pointScript = point.GetComponentInChildren<Point> ();
		pointScript.rotationAxis = new Vector3 ((float)(rand.NextDouble ()), (float)(rand.NextDouble ()), (float)(rand.NextDouble ())).normalized;

		return point;
	}

	GameObject GeneratePlanet (Transform center, float minD, float maxD, float minR, float maxR, float minST, float maxST) {
		GameObject planet = Instantiate (planetPrefab, center);

		maxR = (maxD - minD) / 2;

		if (maxR < minR) {
			Debug.LogWarning ("Minimum radius will produce planet larger than distance range");
			maxR = minR;
		}

		float radius = (float)(rand.NextDouble () * (maxR - minR) + minR);

		Vector3 localScale = planet.transform.localScale;
		localScale.x *= radius * 2;
		localScale.y *= radius * 2;
		planet.transform.localScale = localScale;

		maxD -= radius;
		minD += radius;

		Orbiter orbiter = planet.GetComponent<Orbiter> ();
		orbiter.center = center;
		orbiter.ccw = rand.Next () % 2 == 0;
		orbiter.distance = (float)(rand.NextDouble () * (maxD - minD) + minD);
		orbiter.period = orbitalPeriodConstant * orbiter.distance;
		orbiter.spinPeriod = (float)((rand.Next() % 2 == 0 ? -1 : 1) * rand.NextDouble () * (maxST - minST) + minST);

		return planet;
	}
}
