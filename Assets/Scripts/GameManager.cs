using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }
    
    public UnitHealth PlayerHealth = new UnitHealth(100, 100);
    public UnitArmor PlayerArmor = new UnitArmor(100, 100);

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
}
