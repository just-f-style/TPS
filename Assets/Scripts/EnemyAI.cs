using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private bool _isPlayerNoticed;

    public float triggerDistance;
    public PlayerController player;
    public float viewAngle;
    public float speed;

    private int _heatPoints = 100;

    public Slider healthBar;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.value < 100) healthBar.gameObject.SetActive(true);
        if(healthBar.value == 100) healthBar.gameObject.SetActive(false);
		healthBar.value = _heatPoints;
        viewOfPlayer();

		 Patrol();
         followPlayer();
	}

    public List<Transform> patrolPoint;

    void Patrol()
    {
		if (!_isPlayerNoticed)
        {
			if (_agent.remainingDistance == 0)
			{
				_agent.destination = patrolPoint[UnityEngine.Random.Range(0, patrolPoint.Count)].position;
			}
		}
    }

    void viewOfPlayer()
    {
		var direction = player.transform.position - transform.position;
		if (Vector3.Angle(transform.position, direction) < viewAngle)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
			{
				if (hit.collider.gameObject == player.gameObject) _isPlayerNoticed = true;
				else _isPlayerNoticed = false;
			}
		}
        else _isPlayerNoticed = false;
	}

    void followPlayer()
    {
		if (_isPlayerNoticed) _agent.destination = player.transform.position;
    }

    public void TakeDamage()
    {
        _heatPoints -= 20;

        if(_heatPoints <= 0) Destroy(gameObject);
    }
}
