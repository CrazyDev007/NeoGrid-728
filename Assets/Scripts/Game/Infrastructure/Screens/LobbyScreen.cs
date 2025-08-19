namespace Game.Infrastructure.Screens
{
    public class LobbyScreen : UIScreen
    {
        public void OnClickBtnPlay()
        {
            //Debug.Log(GameManager.Instance.gameMode.ToString());
            LoadingManager.Instance.UnloadScene("Lobby");
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }

        public void OnClickBtnSettings()
        {
            UiManager.ShowScreen(UIScreenType.Setting);
            Hide();
        }
    }
}