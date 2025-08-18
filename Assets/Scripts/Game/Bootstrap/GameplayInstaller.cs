using EasyJection;
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
            Container.Bind<IGameplayListener>().ToSingleton<GameplayListener>(true);
            Container.Bind<GameInitializer>().ToSelf(true);
            Container.Bind<GameplayStatsView>().ToSelf(true);
            Container.Bind<GameplayScreen>().ToSelf().InjectionTo().MethodVoid("Awake");
        }
    }
}