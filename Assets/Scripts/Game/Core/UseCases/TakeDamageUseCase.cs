using Game.Core.Entities;

namespace Game.Core.UseCases
{
    public class TakeDamageUseCase
    {
        public static void Execute(PlayerEntity player, int damage)
        {
            player.TakeDamage(damage);
        }
    }
}