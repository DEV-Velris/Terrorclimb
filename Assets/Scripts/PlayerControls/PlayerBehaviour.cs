using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private ArmorBar armorBar;

    private void PlayerTakeHealDamage(int damage)
    {
        GameManager.gameManager.PlayerHealth.DamageUnit(damage);
        healthBar.SetHealth(GameManager.gameManager.PlayerHealth.CurrentHealth);
    }
    
    private void PlayerHeal(int heal)
    {
        GameManager.gameManager.PlayerHealth.HealUnit(heal);
        healthBar.SetHealth(GameManager.gameManager.PlayerHealth.CurrentHealth);
    }
    
    private void PlayerTakeArmorDamage(int damage)
    {
        GameManager.gameManager.PlayerArmor.DamageArmorUnit(damage);
        armorBar.SetArmor(GameManager.gameManager.PlayerArmor.CurrentArmor);
    }
    
    private void PlayerHealArmor(int armor)
    {
        GameManager.gameManager.PlayerArmor.HealArmorUnit(armor);
        armorBar.SetArmor(GameManager.gameManager.PlayerArmor.CurrentArmor);
    }
}
