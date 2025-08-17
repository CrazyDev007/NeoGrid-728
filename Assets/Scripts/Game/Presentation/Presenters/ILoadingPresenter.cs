namespace Game.Presentation.Presenters
{
    public interface ILoadingPresenter
    {
        public float GetProgress();
        public void UpdateProgress(float progress);
        public void FinishLoading();
        public string GetTestMessage();
    }
}