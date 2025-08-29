using System;
using Game.Application.Interfaces;
using Game.Domain.Entities;
using Game.Infrastructure.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation
{
    public class GameModeView : MonoBehaviour
    {
        [SerializeField] private ToggleGroup toggleGroup;
        private ISaveService _saveService;


        public void Init(ISaveService saveService) => _saveService = saveService;

        private void Start()
        {
            var toggles = toggleGroup.GetComponentsInChildren<Toggle>(true);
            var gameModeConfig = _saveService.LoadGameMode();
            toggles[GetGameModeIndex(gameModeConfig.gameMode)].isOn = true;
        }

        private static int GetGameModeIndex(GameMode gameMode)
        {
            var index = gameMode switch
            {
                GameMode.Easy => 0,
                GameMode.EasyMedium => 1,
                GameMode.Medium => 2,
                GameMode.MediumHard => 3,
                GameMode.Hard => 4,
                _ => throw new ArgumentOutOfRangeException(nameof(gameMode), gameMode, null)
            };

            return index;
        }

        public void OnClickToggle(ToggleView toggleView)
        {
            if (toggleView.IsOn)
            {
                _saveService.SaveGameMode(new GameModeConfig(toggleView.GameMode, toggleView.rowCount,
                    toggleView.columnCount));
            }
        }
    }
}