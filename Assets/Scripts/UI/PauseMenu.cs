using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject inGameUI;

    [Header("Camera")]
    [SerializeField] private CameraController pCamera;

    private float rotateSpeedCamera = 5f;
    private static bool gameIsPaused = false;

    void Start()
    {
        if (pCamera == null)
        {
            Debug.LogWarning("CameraController non assigné dans PauseMenu.");
            return;
        }

        rotateSpeedCamera = pCamera.GetRotateSpeed();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();

            AkSoundEngine.SetRTPCValue("Pause_Menu", gameIsPaused ? 1f : 0f);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        AkSoundEngine.SetRTPCValue("Pause_Menu", 0f);

        if (pCamera != null)
            pCamera.SetRotateSpeed(rotateSpeedCamera);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        AkSoundEngine.SetRTPCValue("Pause_Menu", 1f);

        if (pCamera != null)
            pCamera.SetRotateSpeed(0f);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        AkSoundEngine.PostEvent("Stop_Music", gameObject);
        SceneManager.LoadScene("Saves/Menu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Saves/DinoRushLevelEnd");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
