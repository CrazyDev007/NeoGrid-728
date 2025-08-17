using Game.Bootstrap;
using Managers;
using UnityEngine;

namespace Views.Screens
{
    public class GameplayScreen : UIScreen
    {
        private static void EventOnGameEnded()
        {
            Debug.Log("Game Ended");
            UIManager.Instance.ShowScreen(UIScreenType.GameEnd);
        }

        private void OnEnable()
        {
            GameManager.EventOnGameEnded += EventOnGameEnded;
        }

        private void OnDisable()
        {
            GameManager.EventOnGameEnded -= EventOnGameEnded;
        }
    }
}