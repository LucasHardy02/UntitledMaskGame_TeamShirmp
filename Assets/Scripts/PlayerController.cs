using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Rigidbody _rb;
    public float _walkSpeed = 5f;
    public float _jumpForce = 5f;
    public Vector2 _moveInput;
    public Vector3 _jumpInput;
    private Transform _cameraYaw;
    private Vector3 _movementDirection;
    private Vector3 _inputVector;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cameraYaw = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 _inputVector3 = new Vector3(_moveInput.x, 0, _moveInput.y);

        _movementDirection = Quaternion.Euler(0, _cameraYaw.eulerAngles.y, 0) * _inputVector3;

        if (_movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_movementDirection);
        }
        HandlePlayerMovement();

        if(_movementDirection.sqrMagnitude > .01f)
        {
            Quaternion _targetRotation = Quaternion.LookRotation(_movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 10f * Time.deltaTime);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        //Debug.Log("Move Input: " + _moveInput);
    }
    public void OnJump(InputAction.CallbackContext context)
    { 
        if(context.performed)
        {
            _rb.AddForce(new Vector3(0,_jumpForce,0), ForceMode.Impulse);
        }
        Debug.Log("Jump Input: " + _jumpInput);
    }

    public void HandlePlayerMovement()
    {
        _rb.MovePosition(_rb.position + _movementDirection * _walkSpeed * Time.fixedDeltaTime);
    }
}
