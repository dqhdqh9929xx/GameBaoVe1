using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer; // Reference to the AudioMixer
    [SerializeField] private Slider musicSlider;


    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        // Convert to decibel
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20;

        myMixer.SetFloat("music", dB);
    }

}
