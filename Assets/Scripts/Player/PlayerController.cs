using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject playerModel;

    private PlayerMovement movement;
    private PlayerRotation rotation;
    private PlayerAudio audio;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
        audio = GetComponent<PlayerAudio>();
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
}
