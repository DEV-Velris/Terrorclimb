using System;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent OnShoot;
    public float FireCooldown;

    private float CurrentCooldown;
    
    private Controls _controlMap;

    private void Start()
    {
        CurrentCooldown = FireCooldown;
        _controlMap = new Controls();
        _controlMap.InGame.Enable();
    }

    private void Update()
    {
        if (_controlMap.InGame.Fire.IsPressed())
        {
            if (CurrentCooldown <= 0f)
            {
                OnShoot.Invoke();
                CurrentCooldown = FireCooldown;
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }
}