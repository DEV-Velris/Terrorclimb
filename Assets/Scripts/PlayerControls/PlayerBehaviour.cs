using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField] private HealthBar healthBar;

    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager.PlayerHealth.DamageUnit(damage);
        healthBar.SetHealth(GameManager.gameManager.PlayerHealth.CurrentHealth);
    }
    
    private void PlayerHeal(int heal)
    {
        GameManager.gameManager.PlayerHealth.HealUnit(heal);
        healthBar.SetHealth(GameManager.gameManager.PlayerHealth.CurrentHealth);
    }
}
