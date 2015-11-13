using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	[SerializeField]
	AudioSource audio;
	public AudioClip death;
	public AudioClip treasure;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Score") {
			if (!audio.isPlaying)
				audio.Play();
		}
		if (collider.gameObject.tag == "Death") {
			if (!audio.isPlaying) {
				audio.clip = death;
				audio.Play ();
				}
			}
		if (collider.gameObject.tag == "ObjectEnd") {
			if (!audio.isPlaying) {
				audio.clip = treasure;
				audio.Play ();
			}
		}
	}
}
