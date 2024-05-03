using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    private Controls _controlMap;
    
    // Movements
    [SerializeField] private float walkSpeed = 250f;
    [SerializeField] private float sprintMultiplicator = 2f;
    [SerializeField] private float crouchMultiplicator = 0.5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float airControl = 0.5f;
    private Rigidbody _rigidbody;
    private Vector3 _movement;

    private bool _isGrounded;
    private bool _isSprinting;
    private bool _isCrouching;
    private bool _isJumping;
    
    // Camera
    [SerializeField] private Transform cameraTransform;
    [Range(0.1f, 1f)] [SerializeField] private float xSensitivity = 0.1f;
    [Range(0.1f, 1f)] [SerializeField] private float ySensitivity = 0.1f;
    [Range(0f, 90f)] [SerializeField] private float cameraRotationLimit = 80f;
    private Vector2 _cameraRotation = Vector2.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _controlMap = new Controls();

        Cursor.lockState = CursorLockMode.Locked;
        
        // Création des abonnements
        _controlMap.InGame.Enable();
        _controlMap.InGame.Jump.performed += OnJump;
    }

    private void Update()
    {
        // Movements
        _isSprinting = _controlMap.InGame.Sprint.IsPressed();
        _isCrouching = _controlMap.InGame.Crouch.IsPressed();
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.03f);
        Vector2 actualInput = _controlMap.InGame.Move.ReadValue<Vector2>();
        Vector3 moveInput = new Vector3(actualInput.x, 0, actualInput.y);
        Vector3 moveDirection = cameraTransform.forward * moveInput.z + cameraTransform.right * moveInput.x;
        moveDirection.y = 0;
        
        if (_isGrounded)
        {
            if (_isCrouching)
            {
                _movement = moveDirection.normalized * (walkSpeed * crouchMultiplicator);
            }
            else if (_isSprinting)
            {
                _movement = moveDirection.normalized * (walkSpeed * sprintMultiplicator);
            }
            else
            {
                _movement = moveDirection.normalized * walkSpeed;
            }
        }
        else
        {
            _movement = moveDirection.normalized * (walkSpeed * airControl);
        }
        
        
    }
    
    private void FixedUpdate()
    {
        // Camera
        Vector2 mouse = _controlMap.InGame.View.ReadValue<Vector2>();
        _cameraRotation.x += mouse.x * xSensitivity;
        _cameraRotation.y += mouse.y * ySensitivity;
        _cameraRotation.y = Mathf.Clamp(_cameraRotation.y, -cameraRotationLimit, cameraRotationLimit);
        Quaternion xQuat = Quaternion.AngleAxis(_cameraRotation.x, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(_cameraRotation.y, Vector3.left);
    
        cameraTransform.localRotation = xQuat * yQuat;
        
        Vector3 horizontalMovement = new Vector3(_movement.x, 0, _movement.z) * Time.deltaTime;
        _rigidbody.velocity = new Vector3(horizontalMovement.x, _rigidbody.velocity.y, horizontalMovement.z);
    }
    
    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
