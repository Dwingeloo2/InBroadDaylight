using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject background;
    public Transform player;
    public float height;
    public float width;

	// Use this for initialization
	void Start () {
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }
	
	// Update is called once per frame
	void Update () {
        float playerx = player.position.x;
        float playery = player.position.y;
        transform.position = new Vector3(player.position.x, player.position.y, -5);
	}
}
