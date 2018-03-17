using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject background;
    public Transform player;
    private Vector3 backgroundSize;
    private float camheight;
    private float camwidth;

	// Use this for initialization
	void Start () {
        Camera cam = Camera.main;
        camheight = 2f * cam.orthographicSize;
        camwidth = camheight * cam.aspect;
        backgroundSize = background.GetComponent<MeshRenderer>().bounds.size;
    }
	
	// Update is called once per frame
	void Update () {
        Constrain();
    }

    void Constrain()
    {
        float playerx = player.position.x;
        float playery = player.position.y;
        float lowerBoundX = (-backgroundSize.x / 2) + (camwidth / 2);
        float upperBoundX = (backgroundSize.x / 2) - (camwidth / 2);
        float lowerBoundY = (-backgroundSize.y / 2) + (camheight / 2);
        float upperBoundY = (backgroundSize.y / 2) - (camheight / 2);
        float newX = Mathf.Max(lowerBoundX, Mathf.Min(upperBoundX, playerx));
        float newY = Mathf.Max(lowerBoundY, Mathf.Min(upperBoundY, playery));
        transform.position = new Vector3(newX, newY, -100);
    }
}
