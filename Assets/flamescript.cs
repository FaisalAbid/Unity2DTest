﻿using UnityEngine;
using System.Collections;

public class flamescript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "players";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
