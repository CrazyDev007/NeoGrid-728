using Game.Domain.Entities;

namespace Game.Application.Interfaces
{
    public interface IGameInitializer
    {
        void Initialize(GameMode mode);
    }
}