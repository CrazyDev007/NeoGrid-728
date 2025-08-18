using Game.Presentation;
using UnityEngine;

namespace Game.Infrastructure.Views
{
    public class GameplayStatsView : MonoBehaviour
    {
        [SerializeField] private GameplayStatItemView matchesCountItemView;
        [SerializeField] private GameplayStatItemView turnsCountItemView;

        private IGameplayListener _gameplayListener;

        private void Awake()
        {
        }

        private void Start()
        {
            OnTurnsCountChanged(0);
            OnMatchesCountChanged(0);
            if (_gameplayListener != null)
            {
                ((GameplayListener)_gameplayListener).OnMatchesCountChangeEvent += OnMatchesCountChanged;
                ((GameplayListener)_gameplayListener).OnTurnsCountChangeEvent += OnTurnsCountChanged;
            }
        }

        private void OnEnable()
        {
            //GameManager.OnTurnsCountChanged += OnTurnsCountChanged;
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
            ((GameplayListener)_gameplayListener).OnMatchesCountChangeEvent -= OnMatchesCountChanged;
            ((GameplayListener)_gameplayListener).OnTurnsCountChangeEvent -= OnTurnsCountChanged;
        }
    }
}