using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static int points = 0; // static to survive scene transfers
	public static int level = 0; // static to survive scene transfers
	public AudioClip pickupSound;
	public AudioClip explodeSound;
	public GalaxyGenerator generator;
    public GameObject levelText;

	void Awake() {
		generator.seed = level;
        levelText.GetComponent<Text>().text = "Level  " + (level+1).ToString();
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
}
