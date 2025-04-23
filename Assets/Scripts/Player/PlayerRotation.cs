using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private GameObject playerModel;

    public void HandleRotation(Vector3 moveDirection, float cameraYAngle)
    {
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            transform.rotation = Quaternion.Euler(0f, cameraYAngle, 0f);

            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(
                playerModel.transform.rotation,
                newRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
