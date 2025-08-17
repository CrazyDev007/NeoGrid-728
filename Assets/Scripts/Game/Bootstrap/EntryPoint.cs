using EasyJection;
using Game.Infrastructure;
using Game.Presentation.Presenters;
using UnityEngine;

namespace Game.Bootstrap
{
    [DefaultExecutionOrder(-8000)]
    public class EntryPoint : MonoInstaller
    {
        protected override void InstallBindings()
        {
            Container.Bind<ILoadingPresenter>().To<LoadingPresenter>();
            Container.Bind<LoadingManager>().ToSelf().InjectionTo().MethodVoid("Awake");
        }
    }
}