using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{

    private bool _isPaused;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        _isPaused = false;
    }

    public void OnPauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isPaused = !_isPaused;
            if (_isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void OnConfirm()
    {
        _isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
