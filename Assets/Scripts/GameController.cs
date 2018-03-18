using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int points = 0;
    public AudioClip pickupSound;
    public AudioClip explodeSound;
	
	void Reset() {
		points = 0;
	}


    public void PlayPickupSound()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = pickupSound;
        source.Play();

    }

    public void PlayExplodeSound()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = explodeSound;
        source.Play();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameObject.Find("Death Screen").SetActive(false);
    }
}
