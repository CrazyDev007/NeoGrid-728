using Game.Core.Entities;

namespace Game.Core.UseCases
{
    public class PlayerUseCase
    {
        public void ExecuteTakeDamage(PlayerEntity player, int damage)
        {
            player.TakeDamage(damage);
        }

        public int ExecuteGetPlayerHealth(PlayerEntity player)
        {
            return player.CurrentHealth;
        }
    }
}