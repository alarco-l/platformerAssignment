using UnityEngine;
using System.Collections;

public class OnCollisionDeath : MonoBehaviour {

	[SerializeField]
	Transform transformPlayer;

	private Vector3 checkPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator repop(int sec)
	{
		yield return new WaitForSeconds(sec);
		transformPlayer.position = checkPoint;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Death")
		{
			StartCoroutine(repop(1));
		}
		if (collider.gameObject.tag == "CheckPoint")
		{
			checkPoint = collider.gameObject.transform.position;
		}
	}
}
