using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public float fireDistance;

    public bool fire;

    private EntityHeatPoints _heatPoints;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _heatPoints = GetComponent<EntityHeatPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        viewOfPlayer();
		//followPlayer();
		//Patrol();
		if (_heatPoints.value <= 0) Death();


		if (_isPlayerNoticed) _agent.stoppingDistance = 10;
		else _agent.stoppingDistance = 0;

        //if (Vector3.Distance(transform.position, player.transform.position) <= fireDistance && _isPlayerNoticed && bulletCounter > 0)
        Fire();
        if (bulletCounter == 0) Reload();
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
	public void Death()
    {
        Destroy(gameObject);
    }

    public GameObject bullet;
    public GameObject bulletSpawner;
    private int bulletCounter = 5;
	public float reloadTimer = 5;
    public float waitTime = 1.5f;

	void Fire()
    {
        if(waitTime <= 0)
        {
			waitTime = 1.5f;
			reloadTimer = 5;
			Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
			bulletCounter--;
		}
        else waitTime -= Time.deltaTime;
    }

	void Reload()
    {
        if(bulletCounter == 0)
        {
            reloadTimer -= Time.deltaTime;
        }
        if (reloadTimer <= 0) bulletCounter = 5;
	}
}
