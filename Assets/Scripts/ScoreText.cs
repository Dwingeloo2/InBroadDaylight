using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreText : MonoBehaviour {
	public string prefix = "Score: ";
	public string postfix = "";
	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text> ().text = prefix + gameController.points + postfix;
	}
}
