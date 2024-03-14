using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float speed;
	public float bulletLifeTime;
	public Rigidbody _rigidBody;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody>();
		_rigidBody.freezeRotation = true;
	}
	private void DestroyBullet()
	{
		Destroy(gameObject);
	}
	private void FixedUpdate()
	{
		transform.position += transform.forward * speed * Time.fixedDeltaTime;
		Invoke("DestroyBullet", bulletLifeTime);
	}
}
