using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	[SerializeField]
	Transform player;
	[SerializeField]
	GameObject start;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Teleporter") {
			player.position = start.transform.position;
				}
	}
}
