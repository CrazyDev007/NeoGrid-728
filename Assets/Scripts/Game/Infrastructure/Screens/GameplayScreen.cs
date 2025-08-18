using System;
using Game.Presentation;
using UnityEngine;

namespace Game.Infrastructure.Screens
{
    public class GameplayScreen : UIScreen
    {
        private IGameplayListener _gameplayListener;

        private void EventOnGameEnded()
        {
            Debug.Log("Game Ended");
            UIManager.Instance.ShowScreen(UIScreenType.GameEnd);
        }

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }

        private void OnDisable()
        {
            ((GameplayListener)_gameplayListener).OnGameEndEvent += EventOnGameEnded;
        }
    }
}