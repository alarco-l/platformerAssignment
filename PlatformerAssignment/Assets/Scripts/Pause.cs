using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject canvas;
	private bool isPaused = false;
	static public bool isTuto = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			MenuDisplay();
		}
		if (isPaused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1.0f;
	}

	public void MenuDisplay()
	{
		if (!isTuto) {
			isPaused = !isPaused;
			canvas.SetActive (isPaused);
				}
	}
}
