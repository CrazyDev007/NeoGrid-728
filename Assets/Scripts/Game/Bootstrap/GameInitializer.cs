using System.Collections.Generic;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Infrastructure;
using Game.Presentation;
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

        private IGameplayListener _gameplayListener;

        private void Initialize()
        {
            //Debug.Log(_gameplayListener.GetMessage());
            var cardViews = new List<CardView>();
            var cardMatchUseCase = new CardMatchUseCase((IGameEndListener)_gameplayListener,
                (ICardListener)_gameplayListener, (ICardMatchListener)_gameplayListener,
                (ITurnCompleteListener)_gameplayListener);
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
        }

        private void HandleLoadComplete()
        {
            Debug.Log(">>>>> Load Complete");
            Initialize();
        }

        private void OnEnable()
        {
            LoadingManager.OnLoadComplete += HandleLoadComplete;
        }

        private void OnDisable()
        {
            LoadingManager.OnLoadComplete -= HandleLoadComplete;
        }
    }
}