using Game.Core.Entities;
using Game.Core.UseCases;

namespace Game.Presentation.MVP
{
    public class CardPresenter
    {
        private readonly ICardView _cardView;
        private readonly CardUseCase _cardUseCase;
        private readonly CardEntity _cardEntity;

        public CardPresenter(ICardView cardView)
        {
            _cardView = cardView;
            _cardEntity = new CardEntity();
            _cardUseCase = new CardUseCase();
            //
            UpdateCardView();
        }

        public void OnCardClicked(bool self = true)
        {
            var cardNewState = CardState.Closed;
            if (self)
            {
                cardNewState = _cardEntity.CardState switch
                {
                    CardState.Opened => CardState.Closed,
                    CardState.Closed => CardState.Opened,
                    _ => cardNewState
                };
            }
            else
            {
            }

            _cardUseCase.ChangeCardState(_cardEntity, cardNewState);
            UpdateCardView();
        }

        private void UpdateCardView(bool self = true)
        {
            if (self)
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
            else
            {
                _cardView.CloseCard();
            }
        }
    }
}