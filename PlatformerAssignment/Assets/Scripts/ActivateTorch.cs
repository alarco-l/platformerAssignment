using UnityEngine;
using System.Collections;

public class ActivateTorch : MonoBehaviour {
//	[SerializeField]
//	ParticleRenderer flameIn;
//	[SerializeField]
//	ParticleRenderer flameOut;
//	[SerializeField]
//	ParticleRenderer smoke;

	[SerializeField]
	ParticleEmitter flameIn;
	[SerializeField]
	ParticleEmitter flameOut;
	[SerializeField]
	ParticleEmitter smoke;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			flameIn.enabled = true;
			flameOut.enabled = true;
			smoke.enabled = true;
		}
	}
}
