using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public static int points = 0; // static to survive scene transfers
	public static int level = 0; // static to survive scene transfers
    public AudioClip pickupSound;
	public GalaxyGenerator generator;

	void Awake() {
		generator.seed = level;
	}

	static void ResetPoints() {
		points = 0;
	}

	static void ResetLevel() {
		level = 0;
	}

	public void Advance() {
		level += 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Restart() {
		ResetPoints ();
		ResetLevel ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

    public void PlayPickupSound()
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.clip = pickupSound;
        source.Play();

    }
}
