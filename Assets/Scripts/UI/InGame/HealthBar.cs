using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        SetHealth(GameManager.gameManager.PlayerHealth.CurrentHealth);
    }

    public void SetMaxHealth(int maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
    }
    
    public void SetHealth(int health)
    {
        _healthBar.value = health;
    }
}
