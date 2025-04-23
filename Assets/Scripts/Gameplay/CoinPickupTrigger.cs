using UnityEngine;

public class CoinPickupTrigger : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject sparkEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Donne la pièce immédiatement
        gameManager?.AddCoin(value);

        // Son Wwise
        AkSoundEngine.PostEvent("Get_Coin", gameObject);

        // Spawn du spark à l’emplacement de la pièce
        if (sparkEffectPrefab != null)
        {
            Instantiate(sparkEffectPrefab, transform.position, Quaternion.identity);
        }

        // Supprime la pièce maintenant
        Destroy(gameObject);
    }
}
