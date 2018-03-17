using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatSelect : MonoBehaviour {
	public FileNames fN;

	private Object[] mats;
	private Material p_Material;

	void Start () {
		mats = Resources.LoadAll ("planetMat", typeof(Material));
		Material newMat = (Material)mats[Random.Range(0, mats.Length)];
		GetComponent<Renderer> ().material = newMat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
