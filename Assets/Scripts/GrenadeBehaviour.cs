using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
	public float explosionDelay;
	public GameObject explosionPrefab;

	private void OnCollisionEnter(Collision collision)
	{
		Invoke("Explosion", explosionDelay);
	}

	void Explosion()
	{
		Destroy(gameObject);
		var explosion = Instantiate(explosionPrefab);
		explosion.transform.position = transform.position;
	}
}
