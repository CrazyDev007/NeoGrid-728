namespace Game.Infrastructure.Screens
{
    public class GameEndScreen : UIScreen
    {
        public void OnClickedNextButton()
        {
            //GameManager.Instance.ResetGame();
            LoadingManager.Instance.UnloadScene("Gameplay");
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }
    }
}