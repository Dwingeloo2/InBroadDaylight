using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int points = 0;
    public AudioClip pickupSound;
	
	void Reset() {
		points = 0;
	}


    public void PlayPickupSound()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = pickupSound;
        source.Play();

    }
}
