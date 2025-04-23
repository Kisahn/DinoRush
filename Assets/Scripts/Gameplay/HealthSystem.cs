using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    public int MaxHealth => maxHealth;
    public int CurrentHealth { get; private set; }

    public Vector3 RespawnPoint { get; private set; }

    private PlayerController player;
    private HealthController controller;

    public void Initialize(PlayerController player, HealthController controller)
    {
        this.player = player;
        this.controller = controller;
        CurrentHealth = maxHealth;
        RespawnPoint = player.transform.position;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        RespawnPoint = newPosition;
    }
}
