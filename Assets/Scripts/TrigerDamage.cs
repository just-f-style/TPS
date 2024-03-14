using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class TrigerDamage : MonoBehaviour
{
	private WeaponDamage damage;
	private void Start()
	{
		damage = gameObject.GetComponent<WeaponDamage>();
	}
	public void OnTriggerEnter(Collider other)
	{
		
		var health = other.gameObject.GetComponent<EntityHeatPoints>();

		if (health != null)
		{
			health.value -= damage.value;
		}
	}
}
