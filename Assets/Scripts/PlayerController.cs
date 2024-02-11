using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity;
    public float jumpForce;
    public float speed;
    public float mass;

    private Vector3 _moveVector;
    private float _fallVelocity;
    public static CharacterController _characterController;
    public static bool _isMove;

	void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _characterController.Move(Vector3.down * _fallVelocity * mass * Time.fixedDeltaTime);
    }
	private void Update()
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
				speed = 10f;

				if (Input.GetKeyDown(KeyCode.Space))
				{
					_fallVelocity = -jumpForce;
				}

				if (Input.GetKey(KeyCode.D)) _moveVector += transform.right;
				if (Input.GetKey(KeyCode.A)) _moveVector -= transform.right;
			}
			else speed = 2.5f;
			if (Input.GetKey(KeyCode.W))
			{
				_moveVector += transform.forward;
				if (Input.GetKey(KeyCode.S)) _moveVector -= transform.forward;
			}
		}
		if (_moveVector != Vector3.zero) _isMove = true;
		else _isMove = false;
	}
}
