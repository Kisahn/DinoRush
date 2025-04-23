using UnityEngine;
using System.Collections;

public class RespawnSystem : MonoBehaviour
{
    [SerializeField] private float respawnDelay = 2f;
    private bool isRespawning;

    public void TriggerRespawn(PlayerController player, Vector3 respawnPoint)
    {
        if (!isRespawning)
            StartCoroutine(RespawnCoroutine(player, respawnPoint));
    }

    private IEnumerator RespawnCoroutine(PlayerController player, Vector3 respawnPoint)
    {
        isRespawning = true;

        player.transform.parent = null;
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        player.transform.position = respawnPoint;
        charController.enabled = true;

        player.gameObject.SetActive(true);
        isRespawning = false;
    }
}
