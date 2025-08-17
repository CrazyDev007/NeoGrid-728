using Game.Application.UseCases;

namespace Game.Presentation.Presenters
{
    public class LoadingPresenter
    {
        private readonly LoadSceneUseCase _loadSceneUseCase;
        public LoadingPresenter(LoadSceneUseCase loadSceneUseCase) => _loadSceneUseCase = loadSceneUseCase;
        public bool ShouldShow() => _loadSceneUseCase.IsLoading();
        public float GetProgress() => _loadSceneUseCase.GetProgress();
        public void UpdateProgress(float progress) => _loadSceneUseCase.UpdateProgress(progress);
        public void FinishLoading() => _loadSceneUseCase.FinishLoading();
    }
}