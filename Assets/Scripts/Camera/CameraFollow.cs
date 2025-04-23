using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private Transform pivot;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] private bool useOffsetValues = false;
    [SerializeField] private bool followPlayer = true;

    public void Init(Transform target, Transform pivot)
    {
        this.target = target;
        this.pivot = pivot;

        if (!useOffsetValues && target != null)
        {
            offset = target.position - transform.position;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpdateFollow()
    {
        if (target == null || pivot == null) return;

        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target);
    }

    private void LateUpdate()
    {
        if (!followPlayer || target == null || pivot == null) return;

        // Rotation et position habituelles de la caméra
    }

    public void StopFollowing()
    {
        followPlayer = false;
    }

}
