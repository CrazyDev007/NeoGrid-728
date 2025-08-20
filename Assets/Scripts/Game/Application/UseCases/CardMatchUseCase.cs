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


        public void SelectCard(CardUseCase cardUseCase)
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

            _ = RunCardProcess(_firstSelected, cardUseCase);
            _firstSelected = null;
        }

        private async Task RunCardProcess(CardUseCase cardUseCase1, CardUseCase cardUseCase2)
        {
            // Lock the cards
            cardUseCase1.SetLocked(true);
            cardUseCase2.SetLocked(true);
            //
            cardUseCase2.SetOpen();
            cardUseCase2.CardListener.UpdateCardView();

            await Task.Delay(1000);
            // compare with first
            if (cardUseCase1.GetCardID() == cardUseCase2.GetCardID())
            {
                cardUseCase1.SetMatched();
                cardUseCase2.SetMatched();
                //
                cardUseCase1.CardListener.UpdateCardView();
                cardUseCase2.CardListener.UpdateCardView();

                MatchCount++;
                _cardMatchListener.OnCardMatched(MatchCount);
                if (MatchCount == 6)
                {
                    _gameEndListener.OnGameEnded();
                }
            }
            else
            {
                // Unlock the cards
                cardUseCase1.SetLocked(false);
                cardUseCase2.SetLocked(false);
                //
                cardUseCase1.SetClosed();
                cardUseCase2.SetClosed();
                //
                cardUseCase1.CardListener.UpdateCardView();
                cardUseCase2.CardListener.UpdateCardView();
            }

            TurnCount++;
            _turnCompleteListener.OnTurnCompleted(TurnCount);
        }
    }
}