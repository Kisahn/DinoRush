using UnityEngine;

public class CameraClampAngles : MonoBehaviour
{
    [SerializeField] private float minViewAngle = -30f;
    [SerializeField] private float maxViewAngle = 45f;

    /// <summary>
    /// Clamps the X (vertical) rotation between min and max values.
    /// Handles Euler angle wraparound (0-360 to -180/180).
    /// </summary>
    public Quaternion ClampRotationX(Quaternion rotation)
    {
        Vector3 euler = rotation.eulerAngles;

        if (euler.x > 180f) euler.x -= 360f; // Normalize to -180 to 180

        euler.x = Mathf.Clamp(euler.x, minViewAngle, maxViewAngle);

        return Quaternion.Euler(euler.x, euler.y, 0);
    }
}
