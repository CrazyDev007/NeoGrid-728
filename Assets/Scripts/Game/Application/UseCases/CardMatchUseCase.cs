using System.Threading.Tasks;

namespace Game.Application.UseCases
{
    public class CardMatchUseCase
    {
        // Callbacks
        private readonly IGameEndListener _gameEndListener;
        private readonly ICardListener _cardListener;
        private readonly ICardMatchListener _cardMatchListener;
        private readonly ITurnCompleteListener _turnCompleteListener;

        private CardUseCase _firstSelected;
        private int TurnCount { get; set; }
        private int MatchCount { get; set; }

        private bool GameEnd { get; set; }

        public CardMatchUseCase(IGameEndListener gameEndListener, ICardListener cardListener,
            ICardMatchListener cardMatchListener, ITurnCompleteListener turnCompleteListener)
        {
            _gameEndListener = gameEndListener;
            _cardListener = cardListener;
            _cardMatchListener = cardMatchListener;
            _turnCompleteListener = turnCompleteListener;
        }


        public async Task SelectCard(CardUseCase cardUseCase)
        {
            if (_firstSelected == null)
            {
                _firstSelected = cardUseCase;
                cardUseCase.SetOpen();
                cardUseCase.CardListener.UpdateCardView();
                return;
            }

            if (_firstSelected == cardUseCase)
            {
                _firstSelected = null;
                cardUseCase.SetClosed();
                cardUseCase.CardListener.UpdateCardView();
                return;
            }

            cardUseCase.SetOpen();
            cardUseCase.CardListener.UpdateCardView();

            await Task.Delay(1000);
            // compare with first
            if (_firstSelected.GetCardID() == cardUseCase.GetCardID())
            {
                _firstSelected.SetLocked();
                cardUseCase.SetLocked();
                //
                _firstSelected.CardListener.UpdateCardView();
                cardUseCase.CardListener.UpdateCardView();

                MatchCount++;
                _cardMatchListener.OnCardMatched(MatchCount);
                if (MatchCount == 6)
                {
                    _gameEndListener.OnGameEnded();
                }
            }
            else
            {
                _firstSelected.SetClosed();
                cardUseCase.SetClosed();
                //
                _firstSelected.CardListener.UpdateCardView();
                cardUseCase.CardListener.UpdateCardView();
            }

            TurnCount++;
            _turnCompleteListener.OnTurnCompleted(TurnCount);
            _firstSelected = null;
        }
    }
}