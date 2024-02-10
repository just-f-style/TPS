using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOriginMove : MonoBehaviour
{
	private Transform _OriginTransform;

	public Transform bodyOrigin;

	void Start()
	{
		_OriginTransform = transform;
	}

	void FixedUpdate()
	{
		_OriginTransform.position = new Vector3(bodyOrigin.position.x, bodyOrigin.position.y, bodyOrigin.position.z);
	}
}
