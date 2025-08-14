using Game.Core.Entities;
using Game.Core.UseCases;
using Game.Core.Views;

namespace Game.Core.Presenters
{
    public class PlayerPresenter
    {
        private readonly PlayerView _playerView;
        private readonly PlayerEntity _playerEntity;
        private readonly TakeDamageUseCase _takeDamageUseCase;

        public PlayerPresenter(PlayerView playerView)
        {
            _playerView = playerView;
            _playerEntity = new PlayerEntity(10);
            _takeDamageUseCase = new TakeDamageUseCase();
            UpdatePlayerView();
        }

        public void HandleDamageButtonPressed()
        {
            TakeDamageUseCase.Execute(_playerEntity, 1);
            UpdatePlayerView();
        }

        private void UpdatePlayerView()
        {
            _playerView.UpdateHealthText(_playerEntity.CurrentHealth, _playerEntity.MaxHealth);
        }
    }
}