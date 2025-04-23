using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "DinoRushLevelEnd";

    public void PlayGame()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("MainMenuController: sceneToLoad is not set!");
        }
    }

    public void QuitGame()
    {
        Debug.Log("MainMenuController: Quitting game...");
        Application.Quit();
    }
}
