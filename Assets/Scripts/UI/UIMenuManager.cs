using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{

    [SerializeField] GameObject settingsUI;
    [SerializeField] GameObject mainMenuUI;

    [SerializeField] Slider slider;

    private void Start()
    {
        PlayerPrefs.SetFloat("volume", PlayerPrefs.GetFloat("volume", 0.3f));

        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);

        slider.onValueChanged.AddListener((value) =>
        {
            PlayerPrefs.SetFloat("volume", value);
        });
    }

    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettingsButtonPress()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void OnExitButtonPress()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void OnSettingsBackButtonPress()
    {
        mainMenuUI.SetActive(true);
        settingsUI.SetActive(false);
    }

    public void OnVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("volume", value);
    }
}
