public class UnitHealth
{

    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }

    public UnitHealth(int currentHealth, int maxHealth)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void DamageUnit(int damage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
        }
    }
    
    public void HealUnit(int heal)
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += heal;
        }
        
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
}
