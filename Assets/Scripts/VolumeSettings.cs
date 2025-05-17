using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    // Start is called before the first frame update
    // Sets sliders to correct values when returning to scene
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("savedMusicVolume");
        musicSlider.value = musicVolume;
        
        sfxVolume = PlayerPrefs.GetFloat("savedSFXVolume");
        sfxSlider.value = sfxVolume;
    }

    // Sets music volume based on the slider and saves to PlayerPrefs
    public void MusicVolume (float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("savedMusicVolume", musicVolume);
    }

    // Sets sound volume based on the slider and saves to PlayerPrefs
    public void SFXVolume (float sfxVolume)
    {
        audioMixer.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.SetFloat("savedSFXVolume", sfxVolume);
    }
}
