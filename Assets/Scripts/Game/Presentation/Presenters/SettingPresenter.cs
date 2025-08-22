using Game.Application.UseCases;
using Game.Presentation.Views;

namespace Game.Presentation.Presenters
{
    public class SettingPresenter : ISettingPresenter
    {
        private ISettingView _view;
        private readonly IThemeRepository _themeRepository;
        private readonly ChangeThemeUseCase _changeThemeUseCase;

        public SettingPresenter(ChangeThemeUseCase changeThemeUseCase, IThemeRepository themeRepository)
        {
            _changeThemeUseCase = changeThemeUseCase;
            _themeRepository = themeRepository;
        }


        public void Init(ISettingView view)
        {
            _view = view;
        }

        public void ApplyTheme()
        {
            var currentTheme = _themeRepository.GetCurrentTheme();
            _view.ApplyTheme(currentTheme);
        }

        public void ChangeTheme(string themeName)
        {
            _changeThemeUseCase.ChangeTheme(themeName);
            ApplyTheme();
        }
    }
}