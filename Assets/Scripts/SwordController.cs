using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Animations;

public class SwordController : MonoBehaviour
{
	public int swordDamage;
	public Animator animator;
	public Transform playerTransform;

	public static bool _isBlocking;
	private bool _isAttacking;

	private bool _isPicked;
	private Rigidbody _rigidBody;
	private BoxCollider _collider;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		_collider = GetComponent<BoxCollider>();
	}
	private void Update()
	{
		FirstSwordAttack();
		SwordBlock();

		if (Input.GetKeyDown(KeyCode.G)) Drop();
		if(PickController._isPicked) Pick();
		if (!_isPicked)
		{
			transform.localEulerAngles = new Vector3(0, 0, 90);
			if(transform.position.y <= 0) transform.position = new Vector3(transform.position.x, Mathf.Lerp(0, transform.position.y, Time.deltaTime), transform.position.z);
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" & _isAttacking)
		{
			DamageEnemy(other);
		}
	}
	private void DamageEnemy(Collider other)
	{
		var enemyHealth = other.gameObject.GetComponent<EnemyAI>();
		if (enemyHealth != null)
		{
			enemyHealth.heatPoints -= swordDamage;
		}
	}

	private void FirstSwordAttack()
	{
		if (Input.GetMouseButtonDown(0))
		{
			animator.SetBool("attack", true);
			_isAttacking = true;
		}
		if (Input.GetMouseButtonUp(0))
		{
			animator.SetBool("attack", false);
			_isAttacking = false;
		}
	}

	private void SwordBlock()
	{
		if (Input.GetMouseButtonDown(1))
		{
			animator.SetBool("block", true);
			_isBlocking = true;
		}
		if (Input.GetMouseButtonUp(1))
		{
			animator.SetBool("block", false);
			_isBlocking = false;
		}
	}

	private void Drop()
	{
		if (_isPicked)
		{
			_isPicked = false;
			animator.enabled = false;
			_rigidBody.useGravity = true;
			_collider.isTrigger = false;
			gameObject.transform.SetParent(null);
			PickController._isPicked = false;
		}
	}
	private void Pick()
	{
		transform.position = new Vector3(0, 0, 0);
		_isPicked = true;
		animator.enabled = true;
		_rigidBody.useGravity = false;
		gameObject.transform.SetParent(playerTransform);
		_collider.isTrigger = true;
	}
}
