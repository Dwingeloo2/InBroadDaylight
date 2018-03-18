using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent (typeof(EndOfLevel))]
public class GameController : MonoBehaviour {
	private static int _points = 0;// static to survive scene transfers
	public int points { 
		get { return _points; } 
		set { _points = value; if (_points >= pointsToWin) this.GetComponent<EndOfLevel> ().GoodEnd(); }
	}
	public static int level = 0; // static to survive scene transfers
	private static int pointsToWin;
	public AudioClip pickupSound;
	public AudioClip explodeSound;
	public GalaxyGenerator generator;
    public GameObject levelText;

	void Awake() {
		generator.seed = level;
		generator.orbitalPeriodConstant = 10 * Mathf.Pow (0.8f, (float)(level + 1));
		generator.numPoints = 5 + level;
		pointsToWin = points + generator.numPoints;
        levelText.GetComponent<Text>().text = "Level " + (level+1).ToString();
	}

	void ResetPoints() {
		points = 0;
	}

	void ResetLevel() {
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
