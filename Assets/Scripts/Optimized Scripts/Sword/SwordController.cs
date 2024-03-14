using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Animations;

public class SwordController : MonoBehaviour
{
	public Animator animator;

	public bool isBlocking;
	public bool isAttacking;

	public bool playersSword;
	public bool enemysSword;

	private void Start()
	{
		if(this.tag == "Player") playersSword = true;
		else if(this.tag == "Enemy") enemysSword = true;
	}

	private void Update()
	{
		FirstSwordAttack();
		SwordBlock();
	}

	private void FirstSwordAttack()
	{
		if (Input.GetMouseButtonDown(0))
		{
			animator.SetBool("attack", true);
			isAttacking = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			animator.SetBool("attack", false);
			isAttacking = false;
		}
	}

	private void SwordBlock()
	{
		if (Input.GetMouseButtonDown(1))
		{
			animator.SetBool("block", true);
			isBlocking = true;
		}
		if (Input.GetMouseButtonUp(1))
		{
			animator.SetBool("block", false);
			isBlocking = false;
		}
	}
}
