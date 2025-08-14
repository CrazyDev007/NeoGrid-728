using Managers;
using UnityEngine;

namespace Views.Screens
{
    public class LobbyScreen : UIScreen
    {
        public void OnClickBtnPlay()
        {
            Debug.Log(GameManager.Instance.gameMode.ToString());
        }

        public void OnClickBtnSettings()
        {
            UIManager.Instance.ShowScreen(UIScreenType.Setting);
            Hide();
        }
    }
}