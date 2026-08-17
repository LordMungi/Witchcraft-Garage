using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Dropdown resolutionsDropdown;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider uiVolumeSlider;

    private GlobalSettings GlobalSettings => ServiceProvider.Instance.GetService<GlobalSettings>();

    private void Start()
    {
        resolutionsDropdown.ClearOptions();

        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < GlobalSettings.resolutions.Count; i++)
        {
            resolutionOptions.Add(GlobalSettings.resolutions[i].width + "x" + GlobalSettings.resolutions[i].height + " " + 
                GlobalSettings.resolutions[i].refreshRateRatio.value + "Hz");
        }
        resolutionsDropdown.AddOptions(resolutionOptions);
    }

    private void OnEnable()
    {
        fullscreenToggle.isOn = GlobalSettings.isFullscreen;

        resolutionsDropdown.value = FindCurrentResolutionIndex(); 
        resolutionsDropdown.RefreshShownValue();

        masterVolumeSlider.value = GlobalSettings.masterVolume;
        musicVolumeSlider.value = GlobalSettings.musicVolume;
        sfxVolumeSlider.value = GlobalSettings.sfxVolume;
        uiVolumeSlider.value = GlobalSettings.uiVolume;
    }

    public int FindCurrentResolutionIndex()
    {
        int index = 0;
        for (int i = 0; i < GlobalSettings.resolutions.Count; i++)
        {
            if (GlobalSettings.resolutions[i].width == GlobalSettings.resolutionX && GlobalSettings.resolutions[i].height == GlobalSettings.resolutionY)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public void SetResolution(int index)
    {
        GlobalSettings.resolutionX = GlobalSettings.resolutions[index].width;
        GlobalSettings.resolutionY = GlobalSettings.resolutions[index].height;
    }

    public void SetFullscreen(bool arg)
    {
        GlobalSettings.isFullscreen = arg;
    }
}
