using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDamageController : MonoBehaviour
{
	private WeaponDamage damage;
	private void Start()
	{
		damage = gameObject.GetComponent<WeaponDamage>();
	}
	public void Damage(Collision collision)
	{
		var health = collision.gameObject.GetComponent<EntityHeatPoints>();

		if (health != null)
		{
			health.value -= damage.value;
		}
	}
}
