using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    /// <summary>
    /// Sets initial RTPC and state values at game start.
    /// </summary>
    public void InitializeAudioState()
    {
        float myrtpc = 0;
        AkSoundEngine.SetState("Dead_Or_Alive", "Alive");
        AkSoundEngine.SetRTPCValue("Pause_Menu", myrtpc);
    }

    /// <summary>
    /// Plays jump sound event.
    /// </summary>
    public void PlayJumpSound()
    {
        AkSoundEngine.PostEvent("Space_Jump", gameObject);
    }
}
