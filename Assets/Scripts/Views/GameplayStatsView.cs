using Game.Bootstrap;
using Managers;
using UnityEngine;

namespace Views
{
    public class GameplayStatsView : MonoBehaviour
    {
        [SerializeField] private GameplayStatItemView matchesCountItemView;
        [SerializeField] private GameplayStatItemView turnsCountItemView;

        private void Start()
        {
            OnTurnsCountChanged(0);
            OnMatchesCountChanged(0);
        }

        private void OnEnable()
        {
            GameManager.OnMatchesCountChanged += OnMatchesCountChanged;
            GameManager.OnTurnsCountChanged += OnTurnsCountChanged;
        }

        private void OnTurnsCountChanged(int turnsCount)
        {
            turnsCountItemView.SetCounts(turnsCount);
        }

        private void OnMatchesCountChanged(int matchesCount)
        {
            matchesCountItemView.SetCounts(matchesCount);
        }

        private void OnDisable()
        {
            GameManager.OnMatchesCountChanged -= OnMatchesCountChanged;
            GameManager.OnTurnsCountChanged -= OnTurnsCountChanged;
        }
    }
}