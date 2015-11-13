using UnityEngine;
using System.Collections;

public class EntranceCave : MonoBehaviour {
	[SerializeField]
	TerrainCollider col;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			col.enabled = false;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Player") {
			col.enabled = true;

		}
	}
}
