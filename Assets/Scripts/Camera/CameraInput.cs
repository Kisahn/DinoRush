using UnityEngine;

public class CameraInput : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private bool invertY = false;

    /// <summary>
    /// Returns the horizontal and vertical rotation input, scaled by rotateSpeed.
    /// Y axis is optionally inverted.
    /// </summary>
    public Vector2 GetCameraInput()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        vertical = invertY ? vertical : -vertical;

        return new Vector2(horizontal, vertical);
    }

    public void SetRotateSpeed(float newSpeed) => rotateSpeed = newSpeed;
    public float GetRotateSpeed() => rotateSpeed;
}
