using System.Collections;
using UnityEngine;

public class Distruge : MonoBehaviour
{
	public  float forceRequired = 15.0f; // Forta necesara pentru a distruge obiectul
	public GameObject burstPrefab;

	private void OnCollisionEnter(Collision col)
	{
		//Debug.Log (col.impulse.magnitude);

		if (col.impulse.magnitude > forceRequired)
		{
			Instantiate (burstPrefab, col.contacts [0].point, Quaternion.identity);
			Destroy (gameObject);
		}
	}

}