﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

	[SerializeField]
	 Text score;

	static public uint val;

	// Use this for initialization
	void Start () {
		val = 0;
		score.text = "Score : " + val;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score : " + val;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Score") {
			val += 20;
		}
		if (collider.gameObject.tag == "ObjectEnd") {
			collider.gameObject.SetActive(false);
		}
	}
}
