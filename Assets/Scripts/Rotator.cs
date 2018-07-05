using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

private int speed = 2;

	void Update () 
	{
		transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime*speed);
	}
}