using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {


	public Image backImage;
	private bool isShowned = false;
	private float transition = 0.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (!isShowned)
		{
			return;
		}
		transition += Time.deltaTime;
		backImage.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black,transition);
	}

	public void ToggleEndMenu()
	{
		gameObject.SetActive (true);
		isShowned = true;
	}

}
