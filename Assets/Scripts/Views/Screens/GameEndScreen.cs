using Managers;

namespace Views.Screens
{
    public class GameEndScreen : UIScreen
    {
        public void OnClickedNextButton()
        {
            GameManager.Instance.ResetGame();
            SceneLoadManager.Instance.UnloadScene("Gameplay");
            SceneLoadManager.Instance.LoadSceneAdditive("Gameplay");
        }
    }
}