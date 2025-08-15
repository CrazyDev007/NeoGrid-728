using Game.Presentation.MVP;
using TMPro;
using UnityEngine;

namespace Game.Unity.Views
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public TextMeshProUGUI healthText;
        private PlayerPresenter _playerPresenter;

        private void Awake()
        {
            _playerPresenter = new PlayerPresenter(this);
        }

        public void HandleDamageButtonPressed()
        {
            _playerPresenter.HandleDamageButtonPressed();
        }

        public void DisplayHealth(int currentHealth, int maxHealth)
        {
            healthText.text = currentHealth + "/" + maxHealth;
        }
    }
}