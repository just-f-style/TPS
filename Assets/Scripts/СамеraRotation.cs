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

	public Texture2D cursor;

	private void Start()
	{
		Cursor.SetCursor(cursor, new Vector2(0.01f, 0.01f), CursorMode.ForceSoftware);
	}

	private void CameraRotateXAngle()
	{
		var newXRotationAngle = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
		if (newXRotationAngle > 180) newXRotationAngle -= 360;
		newXRotationAngle = Mathf.Clamp(newXRotationAngle, MinRotationAngle, MaxRotationAngle);
		CameraAxisTransform.localEulerAngles = new Vector3(newXRotationAngle, CameraAxisTransform.localEulerAngles.y, CameraAxisTransform.localEulerAngles.z);
		if (PlayerController._isMove)
		{
			BodyOriginAxisTransform.localEulerAngles = new Vector3(BodyOriginAxisTransform.localEulerAngles.x, BodyOriginAxisTransform.localEulerAngles.y, BodyOriginAxisTransform.localEulerAngles.z);
			if (!PickController._isPicked)
			{

			}
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



            Body.localEulerAngles = new Vector3(BodyOriginAxisTransform.localEulerAngles.x, Mathf.LerpAngle(Body.localEulerAngles.y, RotateBodyAngle, bodyRotationSpeed * Time.deltaTime), BodyOriginAxisTransform.localEulerAngles.z);

		}
	}
	private void CameraRotateYAngle()
	{
		var VectorYRotation = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, VectorYRotation, transform.localEulerAngles.z);

		var _bodyLocalX = BodyOriginAxisTransform.localEulerAngles.x;
		_bodyLocalX = Mathf.LerpAngle(BodyOriginAxisTransform.localEulerAngles.x, _bodyLocalX, bodyRotationSpeed * Time.deltaTime);
		var _bodyLocalY = BodyOriginAxisTransform.localEulerAngles.y;
		_bodyLocalY = Mathf.LerpAngle(BodyOriginAxisTransform.localEulerAngles.y, _bodyLocalY, bodyRotationSpeed * Time.deltaTime);
		var _bodyLocalZ = BodyOriginAxisTransform.localEulerAngles.z;
		_bodyLocalZ = Mathf.LerpAngle(BodyOriginAxisTransform.localEulerAngles.z, _bodyLocalZ, bodyRotationSpeed * Time.deltaTime);

		if(PlayerController._isMove) BodyOriginAxisTransform.localEulerAngles = new Vector3(0 , 0, 0);
		transform.localEulerAngles.Normalize();
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
		if (PlayerController._isMove || !PlayerController._characterController.isGrounded)
		{
			BodyOriginAxisTransform.SetParent(transform);
			BodyOriginAxisTransform.position = transform.position;
		} else BodyOriginAxisTransform.SetParent(null);

		if (!Input.GetKey(KeyCode.LeftAlt))
		{
			CameraRotateXAngle();
			CameraRotateYAngle();
			CursorHideAndLock();
		}
		else CursorShowAndUnlock();
	}

}

