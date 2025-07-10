using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumnSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer; // Reference to the AudioMixer
    [SerializeField] private Slider musicSlider;


    public void SetMusicVolume()
    {
        float volume = musicSlider.value; // Get the value from the slider
        myMixer.SetFloat("music", volume); // Set the volume in the AudioMixer
    }    
}
