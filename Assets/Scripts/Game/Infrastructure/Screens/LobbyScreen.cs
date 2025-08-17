namespace Game.Infrastructure.Screens
{
    public class LobbyScreen : UIScreen
    {
        public void OnClickBtnPlay()
        {
            //Debug.Log(GameManager.Instance.gameMode.ToString());
            SceneLoadManager.Instance.UnloadScene("Lobby");
            SceneLoadManager.Instance.LoadSceneAdditive("Gameplay");
        }

        public void OnClickBtnSettings()
        {
            UIManager.Instance.ShowScreen(UIScreenType.Setting);
            Hide();
        }
    }
}