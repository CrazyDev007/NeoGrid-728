using System.Threading.Tasks;
using Game.Domain.Entities;

namespace Game.Application.UseCases
{
    public class CardUseCase
    {
        public ICardListener CardListener { get; set; }

        private readonly CardEntity _cardEntity;
        public CardUseCase(CardEntity cardEntity) => _cardEntity = cardEntity;
        public int GetCardID() => _cardEntity.CardId;
        public void ChangeCardState(CardState newState) => _cardEntity.CardState = newState;
        public void SetCardID(int newID) => _cardEntity.CardId = newID;
        public CardState GetCardState() => _cardEntity.CardState;
        public int GetCardStateAsInt() => (int)_cardEntity.CardState;
        public bool IsLocked() => _cardEntity.CardState == CardState.Locked;
        public void SetLocked() => _cardEntity.CardState = CardState.Locked;
        public bool IsOpen() => _cardEntity.CardState == CardState.Opened;
        public void SetOpen() => _cardEntity.CardState = CardState.Opened;
        public bool IsClose() => _cardEntity.CardState == CardState.Closed;
        public void SetClosed() => _cardEntity.CardState = CardState.Closed;
        public CardEntity GetCardEntity() => _cardEntity;
    }

    public interface ICardListener
    {
        void UpdateCardView();
    }

    public interface IGameEndListener
    {
        void OnGameEnded();
    }

    public class CardMatchUseCase
    {
        private IGameEndListener _gameEndListener;
        private CardUseCase _firstSelected;
        private int TurnCount { get; set; }
        private int MatchCount { get; set; }

        public CardMatchUseCase(IGameEndListener gameEndListener) => _gameEndListener = gameEndListener;

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
            _firstSelected = null;
        }
    }
}