using UnityEngine;

public class HurtPlayerTrigger : MonoBehaviour
{
    [SerializeField] private int damageToGive = 1;
    [SerializeField] private HealthController healthController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && healthController != null)
        {
            healthController.HurtPlayer(damageToGive);
            AkSoundEngine.PostEvent("Touch_Water", gameObject);
        }
    }
}
