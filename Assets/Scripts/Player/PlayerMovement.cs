using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravityScale = 2f;
    [SerializeField] private float fallMultiplier = 2.5f; // Chute plus rapide

    private CharacterController controller;
    private Vector3 moveDirection;
    private PlayerAudio audio;
    private Animator animator;

    // Coyote Time
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter = 0f;

    // Empêcher gravité immédiate
    private bool justJumped = false;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        audio = GetComponent<PlayerAudio>();
        animator = GetComponentInChildren<Animator>();
    }

    public void HandleMovement()
    {
        float yStore = moveDirection.y;

        // Mouvement horizontal
        Vector3 forwardMovement = transform.forward * Input.GetAxis("Vertical");
        Vector3 rightMovement = transform.right * Input.GetAxis("Horizontal");
        moveDirection = (forwardMovement + rightMovement).normalized * moveSpeed;
        moveDirection.y = yStore;

        // Coyote Time logic
        if (controller.isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Détection du saut
        if (coyoteTimeCounter > 0f && Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpForce;
            animator.SetTrigger("Jump");
            audio.PlayJumpSound();
            coyoteTimeCounter = 0f;
            justJumped = true;
        }

        //  Gestion de la gravité améliorée
        if (!justJumped)
        {
            // Si on tombe, on applique une gravité plus forte
            if (!controller.isGrounded && moveDirection.y < 0)
            {
                moveDirection.y += Physics.gravity.y * gravityScale * fallMultiplier * Time.deltaTime;
            }
            else
            {
                moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
            }
        }
        else
        {
            justJumped = false; // on ignore la gravité pendant 1 frame
        }

        // Application du mouvement
        controller.Move(moveDirection * Time.deltaTime);

        // Animation de déplacement
        bool isMoving = new Vector3(moveDirection.x, 0f, moveDirection.z).magnitude > 0.1f;
        animator.SetBool("Run", isMoving);
        animator.SetBool("Idle", !isMoving);
    }

    public Vector3 GetMoveDirection() => moveDirection;
}
