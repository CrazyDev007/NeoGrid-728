using Game.Application.UseCases;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Infrastructure.Screens
{
    public class SettingScreen : UIScreen, ISettingView
    {
        // Theme
        [SerializeField] private TextMeshProUGUI[] texts;

        [SerializeField] private Image[] images;

        //
        private ISettingPresenter _settingPresenter;

        public void Init(ISettingPresenter settingPresenter)
        {
            _settingPresenter = settingPresenter;
        }

        private void Awake()
        {
            _settingPresenter.ApplyTheme();
        }

        public void OnClickBtnBack()
        {
            UiManager.ShowScreen(UIScreenType.Lobby);
            Hide();
        }

        public void OnClickLightThemeButton()
        {
            _settingPresenter.ChangeTheme("light");
        }

        public void OnClickDarkThemeButton()
        {
            _settingPresenter.ChangeTheme("dark");
        }

        public void ApplyTheme(ThemeDto theme)
        {
            // Text Color
            foreach (var text in texts)
            {
                text.color = ColorUtility.TryParseHtmlString(theme.TextColor, out var textColor)
                    ? textColor
                    : Color.black;
            }

            // Background Color
            foreach (var image in images)
            {
                image.color = ColorUtility.TryParseHtmlString(theme.BackgroundColor, out var backgroundColor)
                    ? backgroundColor
                    : Color.black;
            }
        }
    }
}