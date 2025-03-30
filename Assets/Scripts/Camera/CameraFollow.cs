using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform pivot;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] private bool useOffsetValues = false;

    void Start()
    {
        if (!useOffsetValues && target != null)
        {
            // Calculate offset based on initial positions
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target == null || pivot == null) return;

        // Rotate camera around the pivot with given offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);

        // Prevent camera from going below the player
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        // Always look at the player
        transform.LookAt(target);
    }
}
