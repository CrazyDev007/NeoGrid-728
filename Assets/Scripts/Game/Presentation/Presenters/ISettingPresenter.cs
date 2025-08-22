using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public interface ISettingPresenter
    {
        void Init(ISettingView view);
        void ApplyTheme();
        void ChangeTheme(string themeName);
    }
}