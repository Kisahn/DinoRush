using UnityEngine;

[RequireComponent(typeof(CameraInput), typeof(CameraClampAngles))]
public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform target;

    private CameraInput cameraInput;
    private CameraClampAngles clampAngles;

    void Start()
    {
        cameraInput = GetComponent<CameraInput>();
        clampAngles = GetComponent<CameraClampAngles>();

        if (pivot != null && target != null)
        {
            // Detach pivot from player so it rotates independently
            pivot.position = target.position;
            pivot.parent = null;
        }
    }

    void LateUpdate()
    {
        if (pivot == null || target == null) return;

        // Keep pivot aligned with player position
        pivot.position = target.position;

        // Get user input and apply rotation to pivot
        Vector2 input = cameraInput.GetCameraInput();
        pivot.Rotate(input.y, input.x, 0);

        // Clamp vertical rotation (X axis)
        pivot.rotation = clampAngles.ClampRotationX(pivot.rotation);
    }
}
