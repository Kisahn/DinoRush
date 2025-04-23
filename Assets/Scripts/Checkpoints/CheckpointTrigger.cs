using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [SerializeField] private CheckpointSystem checkpointSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpointSystem.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint triggered at: " + gameObject.name);
        }
    }
}
