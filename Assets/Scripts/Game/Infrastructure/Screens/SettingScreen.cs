using Game.Infrastructure;

namespace Views.Screens
{
    public class SettingScreen : UIScreen
    {
        public void OnClickBtnBack()
        {
            UIManager.Instance.ShowScreen(UIScreenType.Lobby);
            Hide();
        }
    }
}