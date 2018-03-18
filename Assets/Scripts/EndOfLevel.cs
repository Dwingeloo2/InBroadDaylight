using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndOfLevel : MonoBehaviour {

	public UnityEvent onEndLevel;

	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void End(GameObject player){
		print ("End level");
		GameObject explosion = Instantiate (explosionPrefab, player.transform.position, player.transform.rotation);
		player.SetActive(false);
		// Other end of game stuff
		onEndLevel.Invoke ();
	}
}
