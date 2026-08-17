using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GlobalSettings : MonoBehaviour, IService
{
    [Header("Public properties")]

    public AudioMixer mixer;

    public bool IsPersistant => true;

    public int resolutionX = 1920;
    public int resolutionY = 1080;
    public bool isFullscreen = true;
    public float masterVolume = 1;
    public float musicVolume = 1;
    public float sfxVolume = 1;
    public float uiVolume = 1;

    public List<Resolution> resolutions = new List<Resolution>();

    private void Awake()
    {
        RefreshRate refreshRate = Screen.currentResolution.refreshRateRatio;

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRateRatio.value == refreshRate.value)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
    }

    public void ApplySettings()
    {     
        Screen.SetResolution(resolutionX, resolutionY, isFullscreen);
        UpdateAudioMixer("MasterVolume", masterVolume);
        UpdateAudioMixer("MusicVolume", musicVolume);
        UpdateAudioMixer("SFXVolume", sfxVolume);
        UpdateAudioMixer("UIVolume", uiVolume);
    }

    public void CancelSettings()
    {
        resolutionX = Screen.width;
        resolutionX = Screen.height;
        isFullscreen = Screen.fullScreen;

        masterVolume = GetMixerValue("MasterVolume");
        musicVolume = GetMixerValue("MusicVolume");
        sfxVolume = GetMixerValue("SFXVolume");
        uiVolume = GetMixerValue("UIVolume");
    }

    public void DefaultSettings()
    {
        resolutionX = 1920;
        resolutionY = 1080;
        isFullscreen = true;
        masterVolume = 1;
        musicVolume = 1;
        sfxVolume = 1;
        uiVolume = 1;
    }

    private void UpdateAudioMixer(string group, float value)
    {
        if (value > 0)
            mixer.SetFloat(group, Mathf.Log10(Mathf.Clamp(value, 0f, 1f)) * 20);
        else
            mixer.SetFloat(group, -144f);
    }

    public float GetMixerValue(string group)
    {
        mixer.GetFloat(group, out float value);
        return Mathf.Pow(10f, value / 20f);
    }

}
