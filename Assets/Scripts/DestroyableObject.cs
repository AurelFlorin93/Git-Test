using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
	public float forceRequired=3.0f;

	private void OnCollisionEntre(Collision col)
	{
		Debug.Log (col.impulse.magnitude);

		if (col.impulse.magnitude > forceRequired)
			
		{
			Destroy (gameObject);
		}
	}
}
