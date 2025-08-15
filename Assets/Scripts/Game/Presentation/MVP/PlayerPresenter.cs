using Game.Core.Entities;
using Game.Core.UseCases;

namespace Game.Presentation.MVP
{
    public class PlayerPresenter
    {
        private readonly IPlayerView _playerView;
        private readonly PlayerEntity _playerEntity;
        private readonly PlayerUseCase _playerUseCase;

        public PlayerPresenter(IPlayerView playerView)
        {
            _playerView = playerView;
            _playerEntity = new PlayerEntity(10);
            _playerUseCase = new PlayerUseCase();
            UpdatePlayerView();
        }

        public void HandleDamageButtonPressed()
        {
            _playerUseCase.ExecuteTakeDamage(_playerEntity, 1);
            UpdatePlayerView();
        }

        private void UpdatePlayerView()
        {
            _playerView.DisplayHealth(_playerEntity.CurrentHealth, _playerEntity.MaxHealth);
        }
    }
}