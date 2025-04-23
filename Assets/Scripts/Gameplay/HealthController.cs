using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HealthSystem), typeof(HealthUI), typeof(RespawnSystem))]
public class HealthController : MonoBehaviour
{
    [Header("Références externes")]
    [SerializeField] private PlayerController thePlayer;
    [SerializeField] private CameraController pCamera;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private CheckpointSystem checkpointSystem;

    private HealthSystem health;
    private HealthUI healthUI;
    private RespawnSystem respawn;
    private float rotateSpeedCamera;

    void Awake()
    {
        health = GetComponent<HealthSystem>();
        healthUI = GetComponent<HealthUI>();
        respawn = GetComponent<RespawnSystem>();

        rotateSpeedCamera = pCamera.GetRotateSpeed();
        health.Initialize(thePlayer, this);
    }

    void Update()
    {
        healthUI.UpdateHearts(health.CurrentHealth, health.MaxHealth);
    }

    public void HurtPlayer(int damage)
    {
        health.TakeDamage(damage);

        if (health.CurrentHealth <= 0)
        {
            inGameUI.SetActive(false);
            gameOverPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

            if (pCamera.TryGetComponent<CameraFollow>(out CameraFollow camFollow))
                camFollow.StopFollowing();

            thePlayer.gameObject.SetActive(false);
            pCamera.SetRotateSpeed(0f);

            AkSoundEngine.PostEvent("Death", gameObject);
            AkSoundEngine.SetState("Dead_or_Alive", "Dead");
        }
        else
        {
            Vector3 respawnPoint = checkpointSystem != null
                ? checkpointSystem.GetCheckpoint()
                : health.RespawnPoint;

            respawn.TriggerRespawn(thePlayer, respawnPoint);
        }
    }

    public void SetSpawnPoint(Vector3 newPos)
    {
        health.SetSpawnPoint(newPos);
        if (checkpointSystem != null)
            checkpointSystem.SetCheckpoint(newPos);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Saves/DinoRushLevelEnd");
        AkSoundEngine.PostEvent("Stop_Music", gameObject);
        pCamera.SetRotateSpeed(rotateSpeedCamera);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Saves/Menu");
    }
}
