using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {
	[SerializeField]
	Transform player;
	[SerializeField]
	GameObject start;
	[SerializeField]
	Text announcement;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Teleporter") {
			announcement.text = "";
			player.position = start.transform.position;
				}
	}
}
