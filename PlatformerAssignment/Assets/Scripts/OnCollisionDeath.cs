using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnCollisionDeath : MonoBehaviour {

	[SerializeField]
	Transform transformPlayer;
	[SerializeField]
	CharacterController player;

	private Vector3 checkPoint;
	private uint score;
	bool onStart = false;
	private List<GameObject> diamonds;

	// Use this for initialization
	void Start () {
		score = 0;
		diamonds = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator repop(int sec)
	{
		yield return new WaitForSeconds(sec);
		transformPlayer.position = checkPoint;
		player.velocity.Set (0,0,0);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Death")
		{
			if (onStart)
				return;
			StartCoroutine(repop(1));
			UpdateScore.val -= score;
			score = 0;
			foreach (GameObject go in diamonds)
			{
				go.SetActive(true);
			}
			diamonds.Clear();
		}
		if (collider.gameObject.tag == "CheckPoint")
		{
			checkPoint = collider.gameObject.transform.position;
			score = 0;
			diamonds.Clear();
		}
		if (collider.gameObject.tag == "Start")
			onStart = true;
		if (collider.gameObject.tag == "Score") {
			collider.gameObject.SetActive(false);
			score += 20;
			diamonds.Add(collider.gameObject);

		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Start") {
			onStart = false;
		}
	}
}
