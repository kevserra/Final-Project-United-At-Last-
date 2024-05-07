using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolOptions : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    const string MIXER_music = "MusicVolume";
    const string MIXER_sfx = "SFXVolume";
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(MusicVolume);
        sfxSlider.onValueChanged.AddListener(SfxVolume);
    }

    private void MusicVolume(float volValue)
    {
        mixer.SetFloat(MIXER_music, Mathf.Log10(volValue) * 20);
    }
    private void SfxVolume(float volValue)
    {
        mixer.SetFloat(MIXER_sfx, Mathf.Log10(volValue) * 20);
    }








    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
