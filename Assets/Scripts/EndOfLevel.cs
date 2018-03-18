using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndOfLevel : MonoBehaviour {

	public UnityEvent onBadEndLevel;
	public UnityEvent onGoodEndLevel;

	public GameObject explosionPrefab;
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BadEnd() {
		print ("End level");
		GameObject explosion = Instantiate (explosionPrefab, player.transform.position, player.transform.rotation);
		player.SetActive(false);
		// Other end of game stuff
		onBadEndLevel.Invoke ();
	}

	public void GoodEnd() {
		Debug.Log ("Good end level");
		player.SetActive (false);
		onGoodEndLevel.Invoke ();
	}
}
