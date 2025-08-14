using UnityEngine;

namespace Views
{
    public class LobbyScreen : UIScreen
    {
        public void OnClickBtnPlay()
        {
            Debug.Log(GameManager.Instance.gameMode.ToString());
        }

        public void OnClickBtnSettings()
        {
        }
    }
}