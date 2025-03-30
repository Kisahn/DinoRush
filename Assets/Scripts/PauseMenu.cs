using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private static bool gameIsPaused = false;
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject InGameUI;
    [SerializeField]
    private GameObject pCamera;

    private float rotateSpeedCamera;

    // Start is called before the first frame update
    void Start()
    {
        CameraController cameraController = pCamera.GetComponent<CameraController>();
        rotateSpeedCamera = cameraController.getRotateSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();

            } else
            {
                Pause();
            }
              float myrtpc =1;
        AkSoundEngine.SetRTPCValue("Pause_Menu",myrtpc);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        float myrtpc =0;
        AkSoundEngine.SetRTPCValue("Pause_Menu",myrtpc);
        CameraController cameraController = pCamera.GetComponent<CameraController>();
        cameraController.setRotateSpeed(rotateSpeedCamera);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        InGameUI.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        float myrtpc =0;
        AkSoundEngine.SetRTPCValue("Pause_Menu",myrtpc);
        CameraController cameraController = pCamera.GetComponent<CameraController>();
        cameraController.setRotateSpeed(0);
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
