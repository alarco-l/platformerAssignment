using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OnCollisionDeath : MonoBehaviour {

	[SerializeField]
	Transform transformPlayer;
	[SerializeField]
	CharacterController player;
	[SerializeField]
	Text annoucment;

	private Vector3 checkPoint;
	private uint score;
	bool onStart = false;
	private List<GameObject> diamonds;
	private Color color;

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
		annoucment.text = "";
		annoucment.color = color;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Death")
		{
			if (onStart)
				return;
			StartCoroutine(repop(3));
			UpdateScore.val -= score;
			score = 0;
			color = annoucment.color;
			annoucment.color = Color.black;
			annoucment.text = "You are Dead ! \n Respawn in progress...";
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
		if (collider.gameObject.tag == "Announcement") {
			annoucment.text = "Push and use box to activate the switch";
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.tag == "Start") {
			onStart = false;
		}
		if (collider.gameObject.tag == "Announcement") {
			annoucment.text = "";
		}
	}
}
