using UnityEngine;
using Unity.VisualScripting;
public class CameraController : MonoBehaviour
{
    public Transform _player;

    public float _rotationSpeed = 5.0f;

    private float _mouseX, _mouseY;

    void LateUpdate()
    {

        _mouseX = Input.GetAxis("Mouse X") * _rotationSpeed;
        _mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed;

        _mouseY = Mathf.Clamp(_mouseY, -15f, 15f);

        transform.rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
        transform.position = _player.position + transform.rotation * new Vector3(1, (float) 0.7, -3);
    }
}
