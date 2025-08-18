using Game.Presentation;
using UnityEngine;

namespace Game.Infrastructure.Screens
{
    public class GameplayScreen : UIScreen
    {
        private IGameplayListener _gameplayListener;

        private void Awake()
        {
        }

        private void Start()
        {
            if (_gameplayListener != null) ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }

        private static void EventOnGameEnded()
        {
            Debug.Log("Game Ended");
            UIManager.Instance.ShowScreen(UIScreenType.GameEnd);
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }
    }
}