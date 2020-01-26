using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpSpeed = 10.0f;
    [SerializeField]
    private float _gravity = 12.0f;
    private Vector3 _moveDirection = Vector3.zero;
    [SerializeField]
    private bool _hasDoubleJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (_characterController.isGrounded)
        {
            _moveDirection = new Vector3(horizontalInput, 0, 0);
            _moveDirection *= _speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = _jumpSpeed;
                _hasDoubleJump = true;
            }
        } 
        else
        {
            if (Input.GetButtonDown("Jump") && _hasDoubleJump)
            {
                _moveDirection.y = _jumpSpeed;
                _hasDoubleJump = false;
            }
        }

        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);

    }
}
