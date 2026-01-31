using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
    }
}
