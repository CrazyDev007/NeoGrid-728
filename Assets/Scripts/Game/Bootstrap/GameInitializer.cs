using System.Collections.Generic;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Bootstrap
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private CardView cardViewPrefab;

        [Range(2, 6)] [SerializeField] private int rowCount;
        [Range(2, 6)] [SerializeField] private int columnCount;

        [Range(1, 4)] [SerializeField] private float spaceBetweenCards;

        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            var cardViews = new List<CardView>();
            var cardMatchUseCase = new CardMatchUseCase(gameManager, gameManager, gameManager, gameManager);
            // Card Creation Logic
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            var startY = -((rowCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    // Instantiate CardView
                    var cardView = Instantiate(cardViewPrefab,
                        new Vector3(startX + i * spaceBetweenCards, startY + j * spaceBetweenCards, 0),
                        Quaternion.identity);
                    // Create Card Entity and UseCase
                    var cardUseCase = new CardUseCase(new CardEntity());
                    // Create presenter with a shared use case
                    var presenter = new CardPresenter(cardView, cardUseCase, cardMatchUseCase);
                    // Initialize view with presenter
                    cardView.Initialize(presenter);
                    //
                    cardViews.Add(cardView);
                }
            }

            // Initialize Card Symbol
            var cardSymbols = new int[cardViews.Count];
            var halfLength = cardViews.Count / 2;
            for (var i = 0; i < halfLength; i++)
            {
                cardSymbols[i] = i;
                cardSymbols[i + halfLength] = i;
            }

            // Shuffle Symbols
            for (var i = 0; i < cardSymbols.Length; i++)
            {
                var randomIndex = Random.Range(0, cardSymbols.Length);
                (cardSymbols[i], cardSymbols[randomIndex]) = (cardSymbols[randomIndex], cardSymbols[i]);
            }

            // Initialize Cards
            for (var i = 0; i < cardSymbols.Length; i++)
            {
                cardViews[i].UpdateCartID(cardSymbols[i]);
            }


            //GameManager.Instance.AddCardViews(cardViews);
            // Post Initialize
            // Application
            //var cardMatchUseCase = new CardMatchUseCase();

            // Domain + Presentation
            /*foreach (var cardView in cardViews)
            {
                // Create Card Entity and UseCase
                var cardUseCase = new CardUseCase(new CardEntity());
                // Create presenter with a shared use case
                var presenter = new CardPresenter(cardView, cardUseCase, cardMatchUseCase);
                // Initialize view with presenter
                cardView.Initialize(presenter);
            }*/
        }

        private void Awake_1()
        {
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                Instantiate(cardViewPrefab, new Vector3(startX + (i * spaceBetweenCards), 0, 0),
                    Quaternion.identity);
            }
        }

        public void ResetGame()
        {
            /*MatchesCount = 0;
            TurnsCount = 0;
            SelectedCardView = null;
            PairsCount = 0;
            CardViews.Clear();*/
        }
    }
}