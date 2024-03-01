using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordAttack : MonoBehaviour
{
	public int swordDamage;
	public Animator animator;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0)) animator.SetBool("attack", true);
		if (Input.GetMouseButtonUp(0)) animator.SetBool("attack", false);

		if (Input.GetMouseButtonDown(1)) animator.SetBool("block", true);
		if (Input.GetMouseButtonUp(1)) animator.SetBool("block", false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<EnemyAI>().TakeDamage();
		}
	}
}
