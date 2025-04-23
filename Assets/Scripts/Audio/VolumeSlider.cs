using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private string rtpcName = "MasterVolume";
    [SerializeField] private Slider slider;

    private void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        slider.onValueChanged.AddListener(SetVolume);
        SetVolume(slider.value); // Initialise le volume au démarrage
    }

    private void SetVolume(float value)
    {
        AkSoundEngine.SetRTPCValue(rtpcName, value * 100f);
    }
}
