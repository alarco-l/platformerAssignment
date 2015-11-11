using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tuto : MonoBehaviour {
	public GameObject canvas;
	public GameObject HUD;
	private bool tuto = true;
	// Use this for initialization
	void Start () {
	}

	public void 	display()
	{
		tuto = !tuto;
		Pause.isTuto = tuto;
		canvas.SetActive (tuto);
		HUD.SetActive (!tuto);
	}
}
