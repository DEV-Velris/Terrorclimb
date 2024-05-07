using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    private Controls _controlMap;
    private bool _isPaused;

    private void Start()
    {
        _controlMap = new Controls();
        _controlMap.InGame.Enable();
        var rebinds = PlayerPrefs.GetString("keybindings");
        if (!string.IsNullOrEmpty(rebinds))
        {
            _controlMap.LoadBindingOverridesFromJson(rebinds);
        }
        _controlMap.InGame.Pause.performed += context => Pause();
    }

    public void Pause()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            _controlMap.InGame.Disable();
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            pauseMenu.SetActive(true);
        }
        else
        {
            _isPaused = false;
            _controlMap.InGame.Enable();
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
        }
    }

    public void Menu()
    {
        _isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Main menu");
    }
    
}
