using UnityEngine;

[RequireComponent(typeof(CameraFollow))]
[RequireComponent(typeof(CameraInput))]
[RequireComponent(typeof(CameraRotation))]
[RequireComponent(typeof(CameraClampAngles))]
public class CameraController : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform pivot;

    [Header("Modules")]
    [SerializeField] private CameraFollow follow;
    [SerializeField] private CameraRotation rotation;
    [SerializeField] private CameraInput input;
    [SerializeField] private CameraClampAngles clamp;

    void Awake()
    {
        if (follow == null) follow = GetComponent<CameraFollow>();
        if (rotation == null) rotation = GetComponent<CameraRotation>();
        if (input == null) input = GetComponent<CameraInput>();
        if (clamp == null) clamp = GetComponent<CameraClampAngles>();

        input = GetComponent<CameraInput>();
    }

    void Start()
    {
        // Initialise modules avec références externes
        follow.Init(target, pivot);
        rotation.Init(target, pivot);
    }

    void LateUpdate()
    {
        rotation.UpdateRotation(); // fait pivoter le pivot
        follow.UpdateFollow();     // place la caméra autour du pivot
    }

    // Optionnel : accéder depuis l'extérieur
    public float GetRotateSpeed() => input?.GetRotateSpeed() ?? 0f;
    public void SetRotateSpeed(float speed) => input.SetRotateSpeed(speed);
}
