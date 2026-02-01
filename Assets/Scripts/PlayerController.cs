using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator _animator;
    public Rigidbody _rb;
    public float _walkSpeed = 5f;
    public float _jumpForce = 5f;
    public Vector2 _moveInput;
    public Vector3 _jumpInput;
    [SerializeField] private Transform _cameraYaw;
    private Vector3 _movementDirection;
    private Vector3 _inputVector;
    private bool _isGrounded = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cameraYaw = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 _camForward = _cameraYaw.forward;
        Vector3 _camRight = _cameraYaw.right;

        _camForward.y = 0;
        _camRight.y = 0;

        _camForward.Normalize();
        _camRight.Normalize();

        _movementDirection = _camForward * _moveInput.y + _camRight * _moveInput.x;

        if (_movementDirection.sqrMagnitude > .01f)
        {
            Quaternion _targetRotation = Quaternion.LookRotation(_movementDirection);
            _rb.rotation = Quaternion.Slerp(_rb.rotation, _targetRotation, 10f * Time.fixedDeltaTime);

            _rb.MovePosition(_rb.position + _movementDirection * _walkSpeed * Time.fixedDeltaTime);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        //Debug.Log("Move Input: " + _moveInput);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _isGrounded)
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            _isGrounded = false;
        }
        //Debug.Log("Jump Input: " + _jumpInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach(ContactPoint contact in collision.contacts)
            {
                if(Vector3.Angle(contact.normal, Vector3.up) < 45f)
                {
                    _isGrounded = true;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}