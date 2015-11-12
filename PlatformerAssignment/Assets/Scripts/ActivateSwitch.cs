using UnityEngine;
using System.Collections;

public class ActivateSwitch : MonoBehaviour {
	[SerializeField]
	Animation anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Player") {
			anim.enabled = true;
			}
		}
}
