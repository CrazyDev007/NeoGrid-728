namespace Game.Infrastructure.Screens
{
    public class SettingScreen : UIScreen
    {
        public void OnClickBtnBack()
        {
            UiManager.ShowScreen(UIScreenType.Lobby);
            Hide();
        }
    }
}