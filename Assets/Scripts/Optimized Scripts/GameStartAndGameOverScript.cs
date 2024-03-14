using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAndGameOverScript : MonoBehaviour
{
	private EntityHeatPoints heatPoints;
	public GameObject GameOverScreen;

	public void Start()
	{
		Time.timeScale = 1.0f;
		heatPoints = GetComponent<EntityHeatPoints>();
	}
	private void Update()
	{
		GameOverActivation();
	}
	public void GameOverActivation()
	{
		if (heatPoints.value <= 0)
		{
			GameOverScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}

}
