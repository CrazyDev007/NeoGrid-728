using Game.Core.Entities;
using Game.Core.UseCases;
using Managers;

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
            //CardUseCase.SetCardID(_cardEntity, Random.Range(0, 2));
            //
            UpdateCardStateView();
            UpdateCardIDView();
        }

        public void OnCardClicked()
        {
            if (_cardEntity.CardState == CardState.Locked)
            {
                return;
            }

            CardState cardNewState;

            if (GameManager.Instance.SelectedCardView == null)
            {
                GameManager.Instance.SelectedCardView = _cardView;
                cardNewState = CardState.Opened;
            }
            else if (GameManager.Instance.SelectedCardView == _cardView)
            {
                GameManager.Instance.SelectedCardView = null;
                cardNewState = CardState.Closed;
            }
            else
            {
                cardNewState = CardState.Opened;
                _ = GameManager.Instance.CompareCard(GameManager.Instance.SelectedCardView, _cardView);
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
            _cardView.UpdateCardIDText(CardUseCase.GetCardID(_cardEntity));
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

        public void HandleActionUpdateCardID(int cardID)
        {
            CardUseCase.SetCardID(_cardEntity, cardID);
            UpdateCardIDView();
        }
    }
}