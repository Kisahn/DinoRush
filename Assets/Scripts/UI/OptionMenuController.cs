using UnityEngine;

public class OptionMenuController : MonoBehaviour
{
    /// <summary>
    /// Called when the user presses "Back" from the options menu.
    /// Currently only plays a Wwise sound.
    /// </summary>
    public void BackToMainMenu()
    {
        AkSoundEngine.PostEvent("Back", gameObject);

        // TODO: Hide options UI / show main menu UI if needed
        Debug.Log("OptionMenuController: Returning to main menu.");
    }
}
