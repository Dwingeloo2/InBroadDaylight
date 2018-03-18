using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLight : MonoBehaviour {

    public List<Color> colorsToCycle;

	// Use this for initialization
	void Start () {
        int colorIndex = GameController.level % colorsToCycle.Count;
        gameObject.GetComponent<Light>().color = colorsToCycle[colorIndex];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
