using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour {

	public Transform movingwall;
	public Transform position1;
	public Transform position2;

	public Vector3 newPosition;

	public string currentState;
	public float smooth;
	public float resetTime;

	// Use this for initialization
	void Start ()
	{

		ChangeTarget ();	
	}

	// Update is called once per frame
	void FixedUpdate () {
		movingwall.position = Vector3.Lerp (movingwall.position, newPosition, smooth * Time.deltaTime);
	}

	void ChangeTarget()
	{
		if(currentState == "Moving to position1")
		{
			currentState = "Moving to position2";
			newPosition = position2.position;
		} 

		else if(currentState == "Moving to position2")
		{
			currentState = "Moving to position1";
			newPosition = position1.position;
		}
		else  if(currentState == "")
		{
			currentState = "Moving to position2";
			newPosition = position2.position;
		}	
		Invoke ("ChangeTarget",resetTime);
	}
}
