using UnityEngine;
using Views;

namespace Game.Infrastructure
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