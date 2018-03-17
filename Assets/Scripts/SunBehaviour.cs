using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour {

    public float damageRate = 0f;
	private GameObject player;
	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
        if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit))
        {
            if (hit.transform == player.transform)
            {
                player.GetComponent<Player>().AffectHealth(damageRate/hit.distance  );

            }
        }
	}
}
