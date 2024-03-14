using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBlocking : MonoBehaviour
{
	public bool blocking;

	private void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			blocking = true;
		}
		if (Input.GetMouseButtonUp(1))
		{
			blocking = false;
		}
	}
}
