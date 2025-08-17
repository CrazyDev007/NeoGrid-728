using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;

namespace Game.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CardView[] _cardViews;

        private void Awake()
        {
            // Application
            var cardMatchUseCase = new CardMatchUseCase(null);

            // Domain + Presentation
            foreach (var cardView in _cardViews)
            {
                // Create Card Entity and UseCase
                var cardUseCase = new CardUseCase(new CardEntity());
                // Create presenter with a shared use case
                var presenter = new CardPresenter(cardView, cardUseCase, cardMatchUseCase);
                // Initialize view with presenter
                cardView.Initialize(presenter);
            }
        }
    }
}