using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aptechka : MonoBehaviour
{
	public int healValue;
	private void OnTriggerStay(Collider other)
	{
		var heatPoint = other.gameObject.GetComponent<EntityHeatPoints>();
		Debug.Log(heatPoint.value);
		if(heatPoint != null)
		{
			heatPoint.value += healValue;
			Destroy(gameObject);
		}
	}
}
