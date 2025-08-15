using Game.Core.Entities;

namespace Game.Core.UseCases
{
    public class CardUseCase
    {
        public static int GetCardID(CardEntity cardEntity)
        {
            return cardEntity.CardId;
        }

        public static void ChangeCardState(CardEntity cardEntity, CardState newState)
        {
            cardEntity.CardState = newState;
        }

        public static void SetCardID(CardEntity cardEntity, int newID)
        {
            cardEntity.CardId = newID;
        }
    }
}