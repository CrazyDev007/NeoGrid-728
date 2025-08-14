namespace Game.Core.Entities
{
    public class PlayerEntity
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public PlayerEntity(int maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) CurrentHealth = 0;
        }
    }
}