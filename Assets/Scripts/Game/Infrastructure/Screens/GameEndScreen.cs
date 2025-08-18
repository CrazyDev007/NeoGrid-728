using System.Threading.Tasks;

namespace Game.Infrastructure.Screens
{
    public class GameEndScreen : UIScreen
    {
        public void OnClickedNextButton()
        {
            _ = RestartGame();
        }

        private async Task RestartGame()
        {
            //GameManager.Instance.ResetGame();
            LoadingManager.Instance.UnloadScene("Gameplay");
            await Task.Delay(2000);
            LoadingManager.Instance.LoadSceneAdditive("Gameplay");
        }
    }
}