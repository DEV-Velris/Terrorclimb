using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }
    
    public UnitHealth PlayerHealth = new(100, 100);
    public UnitArmor PlayerArmor = new(100, 100);

    public int Score;

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Update()
    {
        if (PlayerHealth.CurrentHealth <= 0)
        {
            SceneManager.LoadScene("Main menu");
            Cursor.lockState = CursorLockMode.None;
        }

        if (Score == 7)
        {
            SceneManager.LoadScene("Main menu");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
