using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СамеraRotation : MonoBehaviour
{
	public float RotationSpeed;

	public float MinRotationAngle;
	public float MaxRotationAngle;
	public int RotateBodyAngle;
	public float bodyRotationSpeed;

	public Transform CameraAxisTransform;
	public Transform BodyOriginAxisTransform;
	public Transform Body;

	private void CameraRotateXAngle()
	{
		var newXRotationAngle = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
		if (newXRotationAngle > 180) newXRotationAngle -= 360;
		newXRotationAngle = Mathf.Clamp(newXRotationAngle, MinRotationAngle, MaxRotationAngle);
		CameraAxisTransform.localEulerAngles = new Vector3(newXRotationAngle, CameraAxisTransform.localEulerAngles.y, CameraAxisTransform.localEulerAngles.z);
		if (PlayerController._isMove)
		{
			BodyOriginAxisTransform.localEulerAngles = new Vector3(BodyOriginAxisTransform.localEulerAngles.x, CameraAxisTransform.localEulerAngles.y, BodyOriginAxisTransform.localEulerAngles.z);
			if (Input.GetKey(KeyCode.W))
				RotateBodyAngle = 0;
			if (Input.GetKey(KeyCode.D))
				RotateBodyAngle = 90;
			if (Input.GetKey(KeyCode.S))
				RotateBodyAngle = 180;
			if (Input.GetKey(KeyCode.A))
				RotateBodyAngle = 270;

			if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
				RotateBodyAngle = 45;
			if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
				RotateBodyAngle = 135;
			if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
				RotateBodyAngle = 225;
			if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
				RotateBodyAngle = 315;

			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
				RotateBodyAngle = 180;

			Body.localEulerAngles = new Vector3(BodyOriginAxisTransform.localEulerAngles.x, Mathf.LerpAngle(Body.localEulerAngles.y, RotateBodyAngle, bodyRotationSpeed * Time.deltaTime), BodyOriginAxisTransform.localEulerAngles.z);

		}
	}
	private void CameraRotateYAngle()
	{
		var VectorYRotation = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, VectorYRotation, transform.localEulerAngles.z);

		
	}
	private void CursorHideAndLock()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	private void CursorShowAndUnlock()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	void Update()
	{
		if (!Input.GetKey(KeyCode.LeftAlt))
		{
			CameraRotateXAngle();
			CameraRotateYAngle();
			CursorHideAndLock();
		}
		else CursorShowAndUnlock();
	}

}

