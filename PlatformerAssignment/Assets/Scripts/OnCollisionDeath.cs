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
	[SerializeField]
	MouseLook mouseLook;
	[SerializeField]
	CharacterController controller;
	[SerializeField]
	MouseLook mouseLookY;
	[SerializeField]
	CharacterMotor motor;
	[SerializeField]
	FPSInputController input;

	private Vector3 checkPoint;
	private uint score;
	bool onStart = false;
	private List<GameObject> diamonds;
	private List<GameObject> torch;
	private Color color;

	// Use this for initialization
	void Start () {
		score = 0;
		diamonds = new List<GameObject>();
		torch = new List<GameObject>();
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
		controller.enabled = true;
		mouseLook.enabled = true;
		motor.enabled = true;
		mouseLookY.enabled = true;
		input.enabled = true;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Death")
		{
			if (onStart)
				return;
			controller.enabled = false;
			mouseLook.enabled = false;
			motor.enabled = false;
			mouseLookY.enabled = false;
			input.enabled = false;
			StartCoroutine(repop(3));
			UpdateScore.val -= score;
			score = 0;
			color = annoucment.color;
			annoucment.color = Color.black;
			annoucment.text = "You are Dead ! \n Respawn in progress... \n\n If torchs are ignited, you are already passed on this way";
			if (diamonds.Count > 0)
			{
				foreach (GameObject go in diamonds)
				{
					go.SetActive(true);
				}
				diamonds.Clear();
			}
			ParticleEmitter []tmp;
			if (torch.Count > 0)
			{
				foreach (GameObject go in torch)
				{
					tmp = go.GetComponentsInChildren<ParticleEmitter>();
					foreach (ParticleEmitter co in tmp)
					{
						co.enabled = true;
					}
				}
				torch.Clear();
			}
		}
		if (collider.gameObject.tag == "CheckPoint")
		{
			checkPoint = collider.gameObject.transform.position;
			score = 0;
			if (diamonds.Count > 0)
				diamonds.Clear();
			if (torch.Count > 0)
				torch.Clear();
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
		if (collider.gameObject.tag == "Torch") {
			torch.Add(collider.gameObject);
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
