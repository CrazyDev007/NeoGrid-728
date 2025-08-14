using Game.Core.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Core.Views
{
    public class PlayerView : MonoBehaviour
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

        public void UpdateHealthText(int currentHealth, int maxHealth)
        {
            healthText.text = currentHealth + "/" + maxHealth;
        }
    }
}