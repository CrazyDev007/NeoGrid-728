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
            // Loading State
            ILoadingState loadingState = new LoadingState();
            // Load Scene Use Case
            ILoadSceneUseCase loadSceneUseCase = new LoadSceneUseCase(loadingState);
            // Loading Presenter
            ILoadingPresenter loadingPresenter = new LoadingPresenter(loadSceneUseCase);
            // Loading Manager
            var loadingManager = FindAnyObjectByType<LoadingManager>();
            loadingManager.Init(loadingPresenter);
            loadingPresenter.Init(loadingManager);
            //
        }
    }
}