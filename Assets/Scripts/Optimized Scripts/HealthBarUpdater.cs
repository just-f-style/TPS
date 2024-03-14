using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdater : MonoBehaviour
{
	private EntityHeatPoints heatPoints;
	public Slider healthBar;

	public void Start()
	{
		heatPoints = GetComponent<EntityHeatPoints>();
	}
	private void Update()
	{
		healthBar.value = heatPoints.value;

		HealtBarActivation();
		HealthBarDeactivation();
	}
	public void HealtBarActivation()
	{
		if (heatPoints.value < 100)
		{
			healthBar.gameObject.SetActive(true);
		}
	}
	public void HealthBarDeactivation()
	{
		if (heatPoints.value <= 0 || heatPoints.value == 100)
		{
			healthBar.gameObject.SetActive(false);
		}
	}
}
