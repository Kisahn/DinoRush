using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    /*[SerializeField]
    private Text lifeText;*/
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
    [SerializeField]
    private PlayerController thePlayer;
    [SerializeField]
    private float respawnLength;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject InGameUI;
    [SerializeField]
    private GameObject pCamera;

    private bool isRespawning;
    private Vector3 startRespawnPoint;
    private Vector3 respawnPoint;

    private float rotateSpeedCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startRespawnPoint = thePlayer.transform.position;
        respawnPoint = startRespawnPoint;

        CameraController cameraController = pCamera.GetComponent<CameraController>();
        rotateSpeedCamera = cameraController.getRotateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }

    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            respawnPoint = startRespawnPoint;
            InGameUI.SetActive(false);
            gameOverPanel.SetActive(true);
            AkSoundEngine.PostEvent("Death", gameObject);
            AkSoundEngine.SetState("Dead_or_Alive", "Dead");
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;

            CameraController cameraController = pCamera.GetComponent<CameraController>();
            cameraController.setRotateSpeed(0);
        }
        Respawn();
        //lifeText.text = "Vies : " + currentHealth;
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.transform.parent = null;
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        thePlayer.gameObject.SetActive(true);

        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        charController.enabled = true;
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Saves/Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        AkSoundEngine.PostEvent("Stop_Music", gameObject);
        SceneManager.LoadScene("Saves/DinoRushLevelEnd");

        CameraController cameraController = pCamera.GetComponent<CameraController>();
        cameraController.setRotateSpeed(rotateSpeedCamera);
    }

}
