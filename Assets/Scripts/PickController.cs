using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickController : MonoBehaviour
{
	public static bool _isPicked;
	public GameObject text;

	private void Start()
	{
		text.SetActive(false);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") text.SetActive(true);
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") text.SetActive(false);
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKey(KeyCode.F)) _isPicked = true;
	}
	private void Update()
	{
		if (_isPicked) text.SetActive(false);
	}

}
