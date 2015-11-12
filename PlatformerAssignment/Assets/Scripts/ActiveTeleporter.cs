using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActiveTeleporter : MonoBehaviour {
	[SerializeField]
	GameObject teleporter;

	[SerializeField]
	Text announcement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			teleporter.SetActive (true);
			announcement.text = "Use the teleporter";
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.tag == "Player")
			announcement.text = "";
	}
}
