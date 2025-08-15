using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Core.UseCases;
using Game.Presentation.MVP;
using Game.Unity.Views;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameMode gameMode;

        private int _matchesCount;
        private int _turnsCount;

        public int PairsCount { get; set; }
        public List<CardView> CardViews { get; set; } = new List<CardView>();

        public ICardView SelectedCardView;

        public int MatchesCount
        {
            get => _matchesCount;
            set
            {
                _matchesCount = value;
                OnMatchesCountChanged?.Invoke(value);
            }
        }

        public int TurnsCount
        {
            get => _turnsCount;
            set
            {
                _turnsCount = value;
                OnTurnsCountChanged?.Invoke(_turnsCount);
            }
        }

        public void AddCardViews(List<CardView> cardViews)
        {
            CardViews.AddRange(cardViews);
            PairsCount = CardViews.Count / 2;
        }

        public static event Action<int> OnMatchesCountChanged;
        public static event Action<int> OnTurnsCountChanged;
        public static event Action EventOnGameEnded;

        private void Awake()
        {
            if (Instance != null && Instance == this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            //
            InitializeGameManager();
        }

        private void InitializeGameManager()
        {
            gameMode = SaveManager.Singleton.LoadGameMode();
        }

        public void SaveGameMode(GameMode gameModeToSave)
        {
            gameMode = gameModeToSave;
            SaveManager.Singleton.SaveGameMode(gameMode);
        }

        public void LoadGameMode()
        {
            gameMode = SaveManager.Singleton.LoadGameMode();
            Debug.Log("Loaded Game Mode: " + gameMode);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        public async Task CompareCard(ICardView cardViewA, ICardView cardViewB)
        {
            await Task.Delay(1000);

            if (CardUseCase.GetCardID(cardViewA.GetCardEntity()) == CardUseCase.GetCardID(cardViewB.GetCardEntity()))
            {
                //Debug.Log("Same Cards");
                cardViewA.ActionLockCard();
                cardViewB.ActionLockCard();
                MatchesCount += 1;
                if (MatchesCount == PairsCount)
                {
                    Debug.Log("Same Pairs");
                    EventOnGameEnded?.Invoke();
                }
            }
            else
            {
                //Debug.Log("Different Cards");
                cardViewA.ActionCloseCard();
                cardViewB.ActionCloseCard();
            }

            TurnsCount += 1;
            SelectedCardView = null;
        }

        public void ResetGame()
        {
            MatchesCount = 0;
            TurnsCount = 0;
            SelectedCardView = null;
            PairsCount = 0;
            CardViews.Clear();
        }
    }
}