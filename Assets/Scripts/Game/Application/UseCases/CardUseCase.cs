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
        public bool IsMatched() => _cardEntity.CardState == CardState.Matched;
        public void SetMatched() => _cardEntity.CardState = CardState.Matched;
        public bool IsOpen() => _cardEntity.CardState == CardState.Opened;
        public void SetOpen() => _cardEntity.CardState = CardState.Opened;
        public bool IsClose() => _cardEntity.CardState == CardState.Closed;
        public void SetClosed() => _cardEntity.CardState = CardState.Closed;
        public bool IsLocked() => _cardEntity.IsLocked;
        public void SetLocked(bool locked) => _cardEntity.IsLocked = locked;
        public CardEntity GetCardEntity() => _cardEntity;
    }
}