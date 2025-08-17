using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class LoadingPresenter : ILoadingPresenter
    {
        private ILoadingView _loadingView;
        private readonly LoadSceneUseCase _loadSceneUseCase;

        public LoadingPresenter()
        {
        }

        public LoadingPresenter(LoadSceneUseCase loadSceneUseCase) => _loadSceneUseCase = loadSceneUseCase;
        public bool ShouldShow() => _loadSceneUseCase.IsLoading();
        public float GetProgress() => _loadSceneUseCase.GetProgress();
        public void UpdateProgress(float progress) => _loadSceneUseCase.UpdateProgress(progress);
        public void FinishLoading() => _loadSceneUseCase.FinishLoading();
        public string GetTestMessage() => "This is test message";
    }
}