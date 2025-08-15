using Game.Core.Entities;
using Game.Core.UseCases;
using Test;
using UnityEngine;

namespace Game.Presentation.MVP
{
    public class CardPresenter
    {
        private readonly ICardView _cardView;
        private readonly CardEntity _cardEntity;

        public CardPresenter(ICardView cardView)
        {
            _cardView = cardView;
            _cardEntity = new CardEntity();
            CardUseCase.SetCardID(_cardEntity, Random.Range(0, 2));
            //
            UpdateCardStateView();
            UpdateCardIDView();
        }

        public void OnCardClicked()
        {
            CardState cardNewState;

            if (TestGameManager.Instance.SelectedCardView == null)
            {
                TestGameManager.Instance.SelectedCardView = _cardView;
                cardNewState = CardState.Opened;
            }
            else if (TestGameManager.Instance.SelectedCardView == _cardView)
            {
                TestGameManager.Instance.SelectedCardView = null;
                cardNewState = CardState.Closed;
            }
            else
            {
                cardNewState = CardState.Opened;
                _ = TestGameManager.Instance.CompareCard(TestGameManager.Instance.SelectedCardView, _cardView);
            }

            CardUseCase.ChangeCardState(_cardEntity, cardNewState);
            UpdateCardStateView();
        }

        private void UpdateCardStateView()
        {
            switch (_cardEntity.CardState)
            {
                case CardState.Opened:
                    _cardView.OpenCard();
                    break;
                case CardState.Closed:
                    _cardView.CloseCard();
                    break;
                case CardState.Locked:
                    _cardView.LockCard();
                    break;
                default:
                    _cardView.CloseCard();
                    break;
            }
        }

        public CardEntity GetCardEntity()
        {
            return _cardEntity;
        }

        private void UpdateCardIDView()
        {
            _cardView.UpdateCardID(CardUseCase.GetCardID(_cardEntity));
        }

        public void HandleActionOpenCard()
        {
        }

        public void HandleActionCloseCard()
        {
            CardUseCase.ChangeCardState(_cardEntity, CardState.Closed);
            UpdateCardStateView();
        }

        public void HandleActionLockCard()
        {
            CardUseCase.ChangeCardState(_cardEntity, CardState.Locked);
            UpdateCardStateView();
        }
    }
}