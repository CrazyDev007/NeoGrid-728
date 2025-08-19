using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ILoadingPresenter
    {
        public void Init(ILoadingView loadingView);
        public float GetProgress();
        public void UpdateProgress(float progress);
        public void FinishLoading();
        public string GetTestMessage();
    }
}