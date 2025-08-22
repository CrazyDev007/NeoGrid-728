using Game.Application.UseCases;
using Game.Infrastructure.Screens;
using Game.Presentation;
using Game.Presentation.Presenters;

namespace Game.Bootstrap
{
    public class LobbyInstaller : MonoInstaller
    {
        protected override void InstallBindings()
        {
            IThemeRepository themeRepository = new PlayerPrefsThemeRepository();
            var changeThemeUseCase = new ChangeThemeUseCase(themeRepository);
            ISettingPresenter settingPresenter = new SettingPresenter(changeThemeUseCase, themeRepository);
            //
            var settingScreen = FindAnyObjectByType<SettingScreen>();
            settingScreen.Init(settingPresenter);
            settingPresenter.Init(settingScreen);
        }
    }
}