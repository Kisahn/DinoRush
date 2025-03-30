using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
   public void Onclick()
    {
        AkSoundEngine.PostEvent("Validation", gameObject);
    }

    public void OnPointerEnter()
    {
        AkSoundEngine.PostEvent("Hoover", gameObject);
    }
}
