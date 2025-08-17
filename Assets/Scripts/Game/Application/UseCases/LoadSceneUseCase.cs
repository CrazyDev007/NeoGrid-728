using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class LoadSceneUseCase
    {
        private readonly LoadingState _loadingState;

        public LoadSceneUseCase(LoadingState loadingState)
        {
            _loadingState = loadingState;
        }

        public LoadingState Execute(string sceneName)
        {
            _loadingState.StartLoading();
            return _loadingState;
        }

        public bool IsLoading()
        {
            return _loadingState.IsLoading;
        }

        public void FinishLoading()
        {
            _loadingState.FinishLoading();
        }

        public void UpdateProgress(float progress)
        {
            _loadingState.UpdateProgress(progress);
        }

        public float GetProgress()
        {
            return _loadingState.Progress;
        }
    }
}