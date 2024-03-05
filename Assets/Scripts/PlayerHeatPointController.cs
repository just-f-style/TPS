using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeatPointController : MonoBehaviour
{
	public int playerHeatpoints;
	public GameObject GameOverScreen;
	public Slider healthBar;

	public void Start()
	{
		Time.timeScale = 1.0f;
	}
	private void Update()
	{
		GameOverActivation();
		healthBar.value = playerHeatpoints;
		if(healthBar.value <= 0) healthBar.gameObject.SetActive(false);
		else healthBar.gameObject.SetActive(true);
	}
	public void GameOverActivation()
	{
		if (playerHeatpoints <= 0)
		{
			GameOverScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}

}
