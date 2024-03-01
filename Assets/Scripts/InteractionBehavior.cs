using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractionBehavior : MonoBehaviour
{
	public GameObject text;

	private void Start()
	{
		text.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			text.SetActive(true);
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.F)) SceneManager.LoadScene(1);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") text.SetActive(false);
	}
}
