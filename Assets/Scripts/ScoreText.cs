using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreText : MonoBehaviour {
	public string prefix = "Score: ";
	public string postfix = "";
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text> ().text = prefix + GameController.points + postfix;
	}
}
