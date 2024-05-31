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
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        _health = StartingHealth;
    }
}