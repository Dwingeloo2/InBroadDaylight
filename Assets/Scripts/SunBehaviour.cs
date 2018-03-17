using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour {
<<<<<<< HEAD

    public float damageRate = 0f;
	public GameObject player;
=======
	public GameObject Player;
>>>>>>> dd969fa69641fa6dfe50dea5aeb5c414a569b621
	// Use this for initialization
	void Start () {
		this.Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
<<<<<<< HEAD
		if(Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit)){
			if (hit.transform == player.transform) {
                player.GetComponent<Player>().AffectHealth(damageRate/hit.distance);

            }
=======
		if(Physics.Raycast(transform.position, (this.Player.transform.position - transform.position), out hit)){
			//print (hit.transform);
			if (hit.transform == this.Player.transform) {
				print ("Player Hit");
			} else {
				print ("Not player");
			}
>>>>>>> dd969fa69641fa6dfe50dea5aeb5c414a569b621
		}
	}
}
