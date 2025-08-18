using EasyJection;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Infrastructure;
using Game.Presentation.Presenters;
using UnityEngine;

namespace Game.Bootstrap
{
    [DefaultExecutionOrder(-8000)]
    public class StartupInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Container.Bind<ILoadingState>().To<LoadingState>();
            Container.Bind<ILoadSceneUseCase>().To<LoadSceneUseCase>();
            Container.Bind<ILoadingPresenter>().To<LoadingPresenter>();
            Container.Bind<LoadingManager>().ToSelf(UseDefaultConstructor: true);
        }
    }
}