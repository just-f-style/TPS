using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageController : MonoBehaviour
{
	private WeaponDamage damage;


	private void Start()
	{
		damage = gameObject.GetComponent<WeaponDamage>();
	}
	public void DamageOrRepel(Collision collision)
	{
		var health = collision.gameObject.GetComponent<EntityHeatPoints>();
		var _entity = collision.gameObject.GetComponent<EntityBlocking>();

		if (_entity != null && _entity.blocking) transform.forward = collision.transform.forward;

		else if (health != null)
		{
			health.value -= damage.value;
			Destroy(gameObject);
		}
	}
}
