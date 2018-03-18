using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour {

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
		Destroy (player);
		// Other end of game stuff
	}
}
