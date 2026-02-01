using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform _player;
    public Vector3 _offset = new Vector3(1f, .7f, -3f);
    public float _rotationSpeed = 5f;
    public Vector2 _lookInput;

    private float yaw;
    private float pitch;

    private void LateUpdate()
    {
        yaw += _lookInput.x * _rotationSpeed * Time.deltaTime;
        pitch -= _lookInput.y * _rotationSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -35f, 60f);

        Quaternion _yawRotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 _desiredPosition = _player.position + _yawRotation * _offset;

        transform.position = Vector3.Lerp(transform.position, _desiredPosition, Time.deltaTime * 10f);
        transform.LookAt(_player.position + Vector3.up * 1.5f);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }
}