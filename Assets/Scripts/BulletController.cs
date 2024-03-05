using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float speed;
	public int bulletDamage;
	public float bulletLifeTime;
	public Rigidbody _rigidBody;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		_rigidBody.freezeRotation = true;
	}

	private void FixedUpdate()
	{
		transform.position += transform.forward * speed * Time.fixedDeltaTime;

		Invoke("DestroyBullet", bulletLifeTime);
	}

	private void DestroyBullet()
	{
		Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		DamageEnemy(collision);
		DamagePlayer(collision);
	}

	private void DamageEnemy(Collision collision)
	{
		var enemyHealth = collision.gameObject.GetComponent<EnemyAI>();
		if (enemyHealth != null)
		{
			enemyHealth.heatPoints -= bulletDamage;
			DestroyBullet();
		}
	}	
	private void DamagePlayer(Collision collision)
	{
		var playerHealth = collision.gameObject.GetComponent<PlayerHeatPointController>();
		if (playerHealth != null && !SwordController._isBlocking)
		{
			playerHealth.playerHeatpoints -= bulletDamage;
			DestroyBullet();
		}
		else if (playerHealth != null && SwordController._isBlocking) transform.forward = playerHealth.transform.forward;
	}
}
