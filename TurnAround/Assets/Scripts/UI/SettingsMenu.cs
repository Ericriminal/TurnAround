using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider m_audioSlider;

    [SerializeField] private Dropdown m_resolutionDropdown;
    [SerializeField] private Toggle m_fullScreenToggle;
    private Resolution[] m_resolutions;

    [SerializeField] private Dropdown m_graphicsDropdown;

    private void Awake() {
        initVolume();
        initResolution();
        initGraphics();
    }

    private void initVolume() {
        float prefVolume = PlayerPrefs.GetFloat("Volume", -1f);

        if (prefVolume != -1f) {
            m_audioSlider.value = prefVolume;
            AudioListener.volume = prefVolume;
        }
    }

    private void initResolution() {
        int prefResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", -1);
        int currentResolutionIndex = initResolutionDropdown();

        initFullScreen();
        if (prefResolutionIndex != -1) {
            Resolution resolution = m_resolutions[prefResolutionIndex];

            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            m_resolutionDropdown.value = prefResolutionIndex;
        } else {
            m_resolutionDropdown.value = currentResolutionIndex;
        }

        m_resolutionDropdown.RefreshShownValue();
    }

    private void initFullScreen() {
        bool prefFullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 0 ? false : true;

        Screen.fullScreen = prefFullScreen;
        m_fullScreenToggle.isOn = prefFullScreen;
    }

    private int initResolutionDropdown() {
        int currentResolutionIndex = 0;
        List<Resolution> resolutions = new List<Resolution>();
        List<string> resolutionOptions = new List<string>();

        m_resolutionDropdown.ClearOptions();
        foreach (Resolution resolution in Screen.resolutions) {
            string option = resolution.width + " x " + resolution.height;

            if (resolution.width > 500 && !resolutionOptions.Contains(option)) {
                resolutions.Add(resolution);
                resolutionOptions.Add(option);
                if (resolution.width == Screen.currentResolution.width &&
                    resolution.height == Screen.currentResolution.height) {
                    currentResolutionIndex = resolutionOptions.Count - 1;
                }
            }
        }
        m_resolutions = resolutions.ToArray();
        m_resolutionDropdown.AddOptions(resolutionOptions);
        return currentResolutionIndex;
    }

    private void initGraphics() {
        int prefGraphicQuality = PlayerPrefs.GetInt("GraphicQuality", -1);

        if (prefGraphicQuality != -1) {
            QualitySettings.SetQualityLevel(prefGraphicQuality);
            m_graphicsDropdown.value = prefGraphicQuality;
        } else {
            QualitySettings.SetQualityLevel(4);
            m_graphicsDropdown.value = 4;
        }
        m_graphicsDropdown.RefreshShownValue();
    }

    public void setVolume() {
        PlayerPrefs.SetFloat("Volume", m_audioSlider.value);
        AudioListener.volume = m_audioSlider.value;
    }

    public void setFullscreen() {
        PlayerPrefs.SetInt("FullScreen", m_fullScreenToggle.isOn ? 1 : 0);
        Screen.fullScreen = m_fullScreenToggle.isOn;
    }

    public void setResolution() {
        Resolution resolution = m_resolutions[m_resolutionDropdown.value];

        PlayerPrefs.SetInt("ResolutionIndex", m_resolutionDropdown.value);
        Debug.Log("resolution.width = " + resolution.width);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void setGraphics() {
        PlayerPrefs.SetInt("GraphicQuality", m_graphicsDropdown.value);
        QualitySettings.SetQualityLevel(m_graphicsDropdown.value);
    }
}
