using Managers;
using UnityEngine;

namespace Views
{
    public class GameModeView : MonoBehaviour
    {
        public void OnClickToggle(ToggleView toggleView)
        {
            if (toggleView.IsOn)
            {
                GameManager.Instance.SaveGameMode(toggleView.GameMode);
            }
        }
    }
}