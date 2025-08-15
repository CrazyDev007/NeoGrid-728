using Game.Core.Entities;

namespace Game.Core.UseCases
{
    public class CardUseCase
    {
        public int GetCardID(CardEntity cardEntity)
        {
            return cardEntity.CardId;
        }

        public void ChangeCardState(CardEntity cardEntity, CardState newState)
        {
            cardEntity.CardState = newState;
        }
    }
}