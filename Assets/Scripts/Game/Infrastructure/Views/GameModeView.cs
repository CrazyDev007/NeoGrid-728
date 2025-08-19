using UnityEngine;

namespace Game.Infrastructure.Views
{
    public class GameModeView : MonoBehaviour
    {
        public void OnClickToggle(ToggleView toggleView)
        {
            if (toggleView.IsOn)
            {
                //GameManager.Instance.SaveGameMode(toggleView.GameMode);
            }
        }
    }
}