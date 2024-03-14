using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	private BulletDamageController _damageController;
	public bool destroyable;

	private void Start()
	{
		_damageController = gameObject.GetComponent<BulletDamageController>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		_damageController.DamageOrRepel(collision);
	}
}
