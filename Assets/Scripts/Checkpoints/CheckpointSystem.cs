using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 lastCheckpoint;

    public Vector3 GetCheckpoint()
    {
        return lastCheckpoint;
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        lastCheckpoint = newCheckpoint;
        Debug.Log("Checkpoint updated to: " + newCheckpoint);
    }
}
