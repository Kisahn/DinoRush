using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 8f;
    [SerializeField] private GameObject playerModel;

    /// <summary>
    /// Rotates the player towards the direction of movement and syncs model rotation.
    /// </summary>
    public void HandleRotation(Vector3 moveDirection, float cameraYAngle)
    {
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            // Rotate the player to match the camera Y axis
            transform.rotation = Quaternion.Euler(0f, cameraYAngle, 0f);

            // Smoothly rotate the model in the movement direction
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(
                playerModel.transform.rotation,
                newRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
