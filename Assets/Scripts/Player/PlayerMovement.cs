using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravityScale = 2f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private PlayerAudio audio;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponent<PlayerAudio>();
    }

    /// <summary>
    /// Handles movement input, jump, gravity, and controller move.
    /// </summary>
    public void HandleMovement()
    {
        float yStore = moveDirection.y;

        Vector3 forwardMovement = transform.forward * Input.GetAxis("Vertical");
        Vector3 rightMovement = transform.right * Input.GetAxis("Horizontal");

        moveDirection = (forwardMovement + rightMovement).normalized * moveSpeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
                audio.PlayJumpSound();
            }
        }

        // Apply gravity
        moveDirection.y += Physics.gravity.y * gravityScale;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public Vector3 GetMoveDirection() => moveDirection;
}
