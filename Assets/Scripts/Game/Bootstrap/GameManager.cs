using System;
using System.Collections.Generic;
using Game.Application.UseCases;
using Game.Presentation.Views;
using UnityEngine;

namespace Game.Bootstrap
{
    public class GameManager : MonoBehaviour, IGameEndListener, ITurnCompleteListener, ICardMatchListener, ICardListener
    {
        public static GameManager Instance;
        //public GameMode gameMode;

        public int PairsCount { get; set; }
        public List<CardView> CardViews { get; set; } = new List<CardView>();

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
            //gameMode = SaveManager.Singleton.LoadGameMode();
        }

        /*public void SaveGameMode(GameMode gameModeToSave)
        {
            gameMode = gameModeToSave;
            SaveManager.Singleton.SaveGameMode(gameMode);
        }*/

        public void LoadGameMode()
        {
            //gameMode = SaveManager.Singleton.LoadGameMode();
            //Debug.Log("Loaded Game Mode: " + gameMode);
        }

        private void QuitGame()
        {
            UnityEngine.Application.Quit();
        }

        /*
         * if (MatchesCount == PairsCount)
                {
                    Debug.Log("Same Pairs");
                    EventOnGameEnded?.Invoke();
                }
         */

        public void ResetGame()
        {
        }

        public void OnGameEnded()
        {
            EventOnGameEnded?.Invoke();
        }

        public void UpdateCardView()
        {
        }

        public void OnTurnCompleted(int turnCount)
        {
            OnTurnsCountChanged?.Invoke(turnCount);
        }

        public void OnCardMatched(int matchCount)
        {
            OnMatchesCountChanged?.Invoke(matchCount);
        }
    }
}