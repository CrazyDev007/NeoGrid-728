using Game.Application.Interfaces;
using Game.Domain.Entities;
using Game.Infrastructure.Views;
using UnityEngine;

namespace Game.Presentation
{
    public class GameModeView : MonoBehaviour
    {
        private ISaveService _saveService;

        public void Init(ISaveService saveService) => _saveService = saveService;

        public void OnClickToggle(ToggleView toggleView)
        {
            if (toggleView.IsOn)
            {
                //GameManager.Instance.SaveGameMode(toggleView.GameMode);
                _saveService.SaveGameMode(new GameModeConfig(toggleView.GameMode, toggleView.rowCount,
                    toggleView.columnCount));
            }
        }
    }
}