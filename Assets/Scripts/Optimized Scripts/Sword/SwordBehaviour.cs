using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
	private TrigerDamageController _damageController;
	private SwordController _controller;

	private void Start()
	{
		_damageController = gameObject.GetComponent<TrigerDamageController>();
		_controller = gameObject.GetComponent<SwordController>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if ((_controller.playersSword && collision.gameObject.tag != "Player") || (_controller.enemysSword && collision.gameObject.tag != "Enemy"))
		{
			if (_controller.isAttacking) _damageController.Damage(collision);
		}
	}
}
