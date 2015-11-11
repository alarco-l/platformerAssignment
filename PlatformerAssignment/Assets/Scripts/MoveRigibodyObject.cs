using UnityEngine;
using System.Collections;

public class MoveRigibodyObject : MonoBehaviour {
	[SerializeField]
	Rigidbody body;
	[SerializeField]
	CharacterController player;

	float mass  = 2.0f;
	float hitForce = 20f;
	private Vector3 impact = Vector3.zero; 
	private bool left = false;

	public float speed = 12.0f;
	public bool invertDirection = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (impact.magnitude > 0.2f){ // if momentum > 0.2...
			player.Move(impact * Time.deltaTime); // move character
		}
		impact = Vector3.Lerp(impact, Vector3.zero, 5f*Time.deltaTime);
		var vel = body.velocity;
		var vel2 = vel.normalized * speed;
		body.velocity = Vector3.Lerp (vel, vel2, 10 * Time.deltaTime);
	}

	IEnumerator constraintes()
	{
		yield return new WaitForSeconds(1);
		body.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
			| RigidbodyConstraints.FreezeRotationZ;
		if (left) {
			body.velocity = new Vector3(0,0,0);
			body.AddRelativeForce (new Vector3(10f,0,0));
		}
		else
		{
			body.velocity = new Vector3(0,0,0);
			body.AddRelativeForce (new Vector3(-10f,0,0));
		}
	}

	void AddImpact(Vector3 force){
		Vector3 dir = force.normalized;
		dir.y = 0.2f;
		impact += dir.normalized * force.magnitude / mass;
	}

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ
				| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			AddImpact((collider.relativeVelocity * hitForce)*-1);
			StartCoroutine(constraintes());
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "LimitForceRight") {
			left = true;
			body.velocity = new Vector3(0,0,0);
			if (!invertDirection)
				body.AddRelativeForce (new Vector3(10f,0,0));
			else
				body.AddRelativeForce (new Vector3(-10f,0,0));
		}
		if (collider.gameObject.tag == "LimitForceLeft") {
			left = true;
			body.velocity = new Vector3(0, 0, 0);
			if (!invertDirection)
				body.AddRelativeForce (new Vector3(-10f,0,0));
			else
				body.AddRelativeForce (new Vector3(10f,0,0));
		}
	}
}
