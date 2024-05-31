using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float StartingHealth = 100f;
    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0f)
            {
                if (GameManager.gameManager.PlayerHealth.CurrentHealth < 100)
                {
                    GameManager.gameManager.PlayerHealth.HealUnit(10);
                }
                else
                {
                    GameManager.gameManager.PlayerArmor.HealArmorUnit(5);
                }

                GameManager.gameManager.Score += 1;
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _health = StartingHealth;
    }
}