using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private float musicVolume;
    [SerializeField] private float sfxVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("savedMusicVolume");
        sfxVolume = PlayerPrefs.GetFloat("savedSFXVolume");

        audioMixer.SetFloat("musicVolume", musicVolume);
        audioMixer.SetFloat("sfxVolume", sfxVolume);
    }
}
