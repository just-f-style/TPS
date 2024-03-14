using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHeatPoints : MonoBehaviour
{
	public int value;

	public int maxValue;
	private void Update()
	{
		value = Mathf.Clamp(value, 0, maxValue);
	}
}
