using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 moveVector;

	//private Transform end;
	public float speed = 4.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;


	private float animationDuration = 3.0f;
	private float startTime;

	private bool isDead = false;


	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController>();
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		if (isDead)
		{
			
			return;
		}

		if (Time.time-startTime < animationDuration)
		{
			controller.Move (Vector3.forward*speed*Time.deltaTime);
			return;
		}


		moveVector = Vector3.zero;

		if (controller.isGrounded)
		{
			verticalVelocity = -0.5f;
		}

		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		moveVector.x = Input.GetAxisRaw ("Horizontal")*speed;
		if (Input.mousePosition.x > Screen.width / 2) {
			moveVector.x = speed;
		} else 
		{
			moveVector.x = -speed;
		}
		moveVector.y = verticalVelocity;
		moveVector.z = speed;


		controller.Move(moveVector* Time.deltaTime);

	}
		
	public void SetSpeed(float modifier)

	{
		speed = 2.0f + modifier;

	}

	//Death function
//------------------------------------------------------------------
	//se executa atunci cand capsula atinge ceve din axa z(in fata).
	//trebuie conditie pusa pentru cazul in care ajunge acasa.

//void OnTriggerEnter (Collider target)
	//{
	//	if (target.gameObject.name == ("Collider")) {
	//		LevelManager.Instance.Victory ();
	//		Debug.Log ("Victory");
	//		return;
	//	}

//	}


	private void OnControllerColliderHit(ControllerColliderHit hit )
	{

		//if (hit.collider.tag == ("Collier"))
		//{
		//	LevelManager.Instance.Victory ();
		//   Debug.Log ("VICTORIE");
	//	}

		if (hit.gameObject.tag == "Final")
		{
			LevelManager.Instance.Victory ();
			Debug.Log ("Victorie");
			return;
		}

		else	if(hit.gameObject.tag== "Obstacol")
     	{
			Death ();   
	   	    Debug.Log ("Death");
			return;
		}
	}
		
	private void Death()
	{
		isDead = true;
		GetComponent<Dificultate>().OnDeath();
	}
//--------------------------------------------------------------------
}