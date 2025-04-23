using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public void InitializeAudioState()
    {
        float myrtpc = 0;
        AkSoundEngine.SetState("Dead_Or_Alive", "Alive");
        AkSoundEngine.SetRTPCValue("Pause_Menu", myrtpc);
    }

    public void PlayJumpSound()
    {
        AkSoundEngine.PostEvent("Space_Jump", gameObject);
    }
}
