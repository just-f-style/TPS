using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBarLookAtPlayer : MonoBehaviour
{
	public Transform playerCamera;

	private void LateUpdate()
	{
		transform.LookAt(playerCamera);
	}
}
