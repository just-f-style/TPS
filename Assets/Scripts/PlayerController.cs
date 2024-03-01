using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public float jumpForce;
    
    public float mass;

	public float defaultSprintForce;
	public float slowSprintForce;

	public float walkSpeed;
	public float slowRunSpeed;


	private Vector3 _moveVector;
    public static CharacterController _characterController;

	private float _fallVelocity;
	private float _speed;
	public float _sprintForce;

	private float _defaultSprintTimer;
	private float _slowSprintTimer;

	public static bool _isMove;
	private bool _movementSpeedSwitcher;
	private bool _isSprinting;

	void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(_moveVector * _speed * _sprintForce * Time.fixedDeltaTime);

        _characterController.Move(Vector3.down * _fallVelocity * mass * Time.fixedDeltaTime);
    }

	private void Update()
	{
		Move();
		Sprint();

		if(!_isSprinting) MovementSpeedCheck();

		if (Input.GetKeyDown(KeyCode.LeftControl)) _movementSpeedSwitcher = !_movementSpeedSwitcher;

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			_defaultSprintTimer = 0.5f;
			_slowSprintTimer = 3.5f;
			_isSprinting = true;
		}

		if (_moveVector != Vector3.zero) _isMove = true;
		else _isMove = false;
	}

	private void Move()
	{
		_moveVector = Vector3.zero;

		if (!Input.GetKey(KeyCode.LeftAlt))
		{
			if (_characterController.isGrounded)
			{
				if (_fallVelocity > 10)
				{
					_fallVelocity = 0;
				}
				_speed = slowRunSpeed;

				if (Input.GetKeyDown(KeyCode.Space))
				{
					_fallVelocity = -jumpForce;
				}

				if (Input.GetKey(KeyCode.D)) _moveVector += transform.right;
				if (Input.GetKey(KeyCode.A)) _moveVector -= transform.right;
			}
			else _speed = walkSpeed;
			if (Input.GetKey(KeyCode.W)) _moveVector += transform.forward;
			if (Input.GetKey(KeyCode.S)) _moveVector -= transform.forward;
		}
	}

	private void Sprint()
	{
		if(_isSprinting)
		{
			if (_defaultSprintTimer > 0)
			{
				_sprintForce = defaultSprintForce;
				_defaultSprintTimer -= Time.deltaTime;
			}
			if (_defaultSprintTimer <= 0)
			{
				if (_slowSprintTimer > 0)
				{
					_sprintForce = slowSprintForce;
					_slowSprintTimer -= Time.deltaTime;
				}
				if (_slowSprintTimer <= 0)
				{
					_sprintForce = 1;
					_isSprinting = false;
				}
			}
		}
	}

	private void MovementSpeedCheck()
	{
		if (_movementSpeedSwitcher) _speed = walkSpeed;
		else _speed = slowRunSpeed;
	}

}
