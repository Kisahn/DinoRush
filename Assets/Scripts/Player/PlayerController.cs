using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Références nécessaires")]
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject playerModel;

    [Header("Modules")]
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerRotation rotation;
    [SerializeField] private PlayerAudio audio;

    void Awake()
    {
        if (movement == null) movement = GetComponent<PlayerMovement>();
        if (rotation == null) rotation = GetComponent<PlayerRotation>();
        if (audio == null) audio = GetComponent<PlayerAudio>();
    }

    void Start()
    {
        audio.InitializeAudioState();
    }

    void Update()
    {
        movement.HandleMovement();
        rotation.HandleRotation(movement.GetMoveDirection(), pivot.rotation.eulerAngles.y);
    }

    // Méthodes accessibles depuis d'autres scripts si besoin
    public void PlayJumpSound() => audio.PlayJumpSound();
    public Vector3 GetMoveDirection() => movement.GetMoveDirection();
}
