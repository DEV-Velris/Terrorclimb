using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    private Slider _armorBar;

    private void Start()
    {
        _armorBar = GetComponent<Slider>();
    }

    private void Update()
    {
        SetArmor(GameManager.gameManager.PlayerArmor.CurrentArmor);
    }

    public void SetMaxArmor(int maxHealth)
    {
        _armorBar.maxValue = maxHealth;
        _armorBar.value = maxHealth;
    }
    
    public void SetArmor(int health)
    {
        _armorBar.value = health;
    }
}
