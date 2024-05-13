public class UnitArmor
{
    
    public int CurrentArmor { get; set; }
    public int MaxArmor { get; set; }

    public UnitArmor(int currentHealth, int maxHealth)
    {
        CurrentArmor = currentHealth;
        MaxArmor = maxHealth;
        
        if (CurrentArmor > MaxArmor)
        {
            CurrentArmor = MaxArmor;
        }
    }

    public void DamageArmorUnit(int damage)
    {
        if (CurrentArmor > 0)
        {
            CurrentArmor -= damage;
        }
    }
    
    public void HealArmorUnit(int armor)
    {
        if (CurrentArmor < MaxArmor)
        {
            CurrentArmor += armor;
        }
        
        if (CurrentArmor > MaxArmor)
        {
            CurrentArmor = MaxArmor;
        }
    }
    
}
