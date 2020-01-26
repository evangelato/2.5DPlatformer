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
    private int _coinNum = 0;
    private UIManager _uiManager;
    private GameManager _gameManager;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _respawnLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("Player: The UI Manager is NULL");
        }
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {

            Debug.LogError("Player: The Game Manager is NULL");
        }
        _characterController = GetComponent<CharacterController>();

        _uiManager.UpdateLivesDisplay(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f) 
        {
            _characterController.enabled = false;
            _lives--;
            if (_lives <= 0)
            {
                _gameManager.RestartGame();
            } 
            else {
                transform.position = _respawnLocation.transform.position;
                _uiManager.UpdateLivesDisplay(_lives);
            }
            _characterController.enabled = true;
        } else {
            CalculateMovement();
        }
        
        
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

    public void onCoinCollect() 
    {
        _coinNum ++;
        _uiManager.UpdateCoinDisplay(_coinNum);
    }

}
