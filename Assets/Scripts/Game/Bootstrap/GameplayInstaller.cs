using Game.Infrastructure.Screens;
using Game.Infrastructure.Views;
using Game.Presentation;
using UnityEngine;

namespace Game.Bootstrap
{
    [DefaultExecutionOrder(-8000)]
    public class GameplayInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            IGameplayListener gameplayListener = new GameplayListener();
            // GameInitializer
            var gameInitializer = FindAnyObjectByType<GameInitializer>();
            gameInitializer.Init(gameplayListener);
            // GameplayStatsView
            var gameplayStatsView = FindAnyObjectByType<GameplayStatsView>();
            gameplayStatsView.Init(gameplayListener);
            // GameplayScreen
            var gameplayScreen = FindAnyObjectByType<GameplayScreen>();
            gameplayScreen.Init(gameplayListener);
        }
    }
}