using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private GameStateData _gameStateData;
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _restartMenuUI;
    [SerializeField] private GameObject _controlsMenuUI;
    [SerializeField] private GameObject _comicsMenuUI;
    [SerializeField] private GameObject _successMenuUI;
    [SerializeField] private GameObject _backgroundImageUI;
    [SerializeField] private GameObject _inventoryMenuUI;

    private bool _isPaused = false;

    private void Start()
    {
        _isPaused = true;
        _gameStateData.IsGameActive = false;
        _gameStateData.IsBuildFinished = false;
        DisableAllMenus();
        _comicsMenuUI.SetActive(true);
        _backgroundImageUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumeButtonPress()
    {
        _isPaused = false;
        _gameStateData.IsGameActive = true;
        Time.timeScale = 1f;
        _pauseMenuUI.SetActive(false);
        _backgroundImageUI.SetActive(false);
    }

    public void OnExitButtonPress()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0f : 1f;
            _pauseMenuUI.SetActive(_isPaused);
            _backgroundImageUI.SetActive(_isPaused);
            _inventoryMenuUI.SetActive(!_isPaused);
            _gameStateData.IsGameActive = !_isPaused;
        }
    }
   
    public void OnCoolButtonPress()
    {
        _comicsMenuUI.SetActive(false);
        _controlsMenuUI.SetActive(true);
    }

    public void OnLetsgoButtonPress()
    {
        DisableAllMenus();
        Time.timeScale = 1f;
        _gameStateData.IsGameActive = true;
        _inventoryMenuUI.SetActive(true);
    }

    public void OnSuccessMenu()
    {
        Time.timeScale = 0f;
        _backgroundImageUI.SetActive(true);
        _successMenuUI.SetActive(true);
        _gameStateData.IsGameActive = false;
    }

    public void OnRestartMenu()
    {
        Time.timeScale = 0f;
        _backgroundImageUI.SetActive(true);
        _restartMenuUI.SetActive(true);
        _gameStateData.IsGameActive = false;
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnGoButtonPress()
    {
        _inventoryMenuUI.SetActive(false);
        _gameStateData.IsBuildFinished = true;
    }

    private void DisableAllMenus()
    {
        _pauseMenuUI.SetActive(false);
        _restartMenuUI.SetActive(false); 
        _comicsMenuUI.SetActive(false); 
        _controlsMenuUI.SetActive(false);
        _backgroundImageUI.SetActive(false);
        _successMenuUI.SetActive(false);
    }
}
