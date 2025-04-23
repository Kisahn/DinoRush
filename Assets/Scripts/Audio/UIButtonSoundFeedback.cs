using UnityEngine;

public class UIButtonSoundFeedback : MonoBehaviour
{
    [SerializeField] private string clickEvent = "Validation";
    [SerializeField] private string hoverEvent = "Hoover";

    /// <summary>
    /// Called by the UI Button's OnClick event
    /// </summary>
    public void OnClick()
    {
        if (!string.IsNullOrEmpty(clickEvent))
            AkSoundEngine.PostEvent(clickEvent, gameObject);
    }

    /// <summary>
    /// Called by the UI EventTrigger on PointerEnter
    /// </summary>
    public void OnPointerEnter()
    {
        if (!string.IsNullOrEmpty(hoverEvent))
            AkSoundEngine.PostEvent(hoverEvent, gameObject);
    }
}
