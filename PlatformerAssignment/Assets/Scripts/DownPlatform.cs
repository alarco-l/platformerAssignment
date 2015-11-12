using UnityEngine;
using System.Collections;

public class DownPlatform : MonoBehaviour {

	public bool isFall = false;
	public float yMin = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= yMin)
						isFall = false;
		if (isFall)
			transform.Translate(0, 0, -Time.deltaTime * 4.0f);
	}
}
