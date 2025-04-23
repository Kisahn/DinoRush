using UnityEngine;

[RequireComponent(typeof(CameraInput), typeof(CameraClampAngles))]
public class CameraRotation : MonoBehaviour
{
    private Transform pivot;
    private Transform target;

    private CameraInput cameraInput;
    private CameraClampAngles clampAngles;

    public void Init(Transform target, Transform pivot)
    {
        this.target = target;
        this.pivot = pivot;

        if (pivot != null && target != null)
        {
            pivot.position = target.position;
            pivot.parent = null;
        }

        cameraInput = GetComponent<CameraInput>();
        clampAngles = GetComponent<CameraClampAngles>();
    }

    public void UpdateRotation()
    {
        if (pivot == null || target == null) return;

        pivot.position = target.position;

        Vector2 input = cameraInput.GetCameraInput();
        pivot.Rotate(input.y, input.x, 0);

        pivot.rotation = clampAngles.ClampRotationX(pivot.rotation);
    }
}
