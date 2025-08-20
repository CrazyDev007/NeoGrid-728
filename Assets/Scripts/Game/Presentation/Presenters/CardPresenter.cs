using Game.Application.UseCases;
using Game.Presentation.Views;
using UnityEngine;

namespace Game.Presentation.Presenters
{
    public class CardPresenter : ICardListener
    {
        private readonly ICardView _cardView;
        private readonly CardUseCase _cardUseCase;
        private readonly CardMatchUseCase _cardMatchUseCase;

        public CardPresenter(ICardView cardView, CardUseCase cardUseCase, CardMatchUseCase cardMatchUseCase)
        {
            _cardView = cardView;
            _cardUseCase = cardUseCase;
            _cardMatchUseCase = cardMatchUseCase;
            //CardUseCase.SetCardID(_cardEntity, Random.Range(0, 2));
            _cardUseCase.CardListener = this;
        }

        public void Initialize()
        {
            UpdateCardStateView();
            UpdateCardIDView();
        }

        public void OnCardClicked()
        {
            if (_cardUseCase.IsLocked())
            {
                return;
            }

            _cardMatchUseCase.SelectCard(_cardUseCase);
            //_view.Flip();
            //if(result==true);
            //_view.ShowMatched();
            //else if(result==false)
            //_view.ResetFlipAfterDelay();
            //UpdateCardStateView();
        }

        private void UpdateCardStateView()
        {
            if (_cardUseCase.IsOpen())
                _cardView.OpenCard();
            else if (_cardUseCase.IsClose())
                _cardView.CloseCard();
            else if (_cardUseCase.IsMatched())
                _cardView.LockCard();
            else
                _cardView.CloseCard();
        }

        private void UpdateCardIDView()
        {
            _cardView.UpdateCardIDText(_cardUseCase.GetCardID());
        }

        public void HandleActionOpenCard()
        {
        }

        public void HandleActionCloseCard()
        {
            _cardUseCase.SetClosed();
            UpdateCardStateView();
        }

        public void HandleActionLockCard()
        {
            _cardUseCase.SetMatched();
            UpdateCardStateView();
        }

        public void HandleActionUpdateCardID(int cardID)
        {
            _cardUseCase.SetCardID(cardID);
            UpdateCardIDView();
        }

        public void UpdateCardView()
        {
            UpdateCardStateView();
        }

        public void OnGameEnded()
        {
            Debug.Log("Game ended");
        }
    }
}