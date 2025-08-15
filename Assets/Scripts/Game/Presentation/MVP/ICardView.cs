using Game.Core.Entities;

namespace Game.Presentation.MVP
{
    public interface ICardView
    {
        void OpenCard();
        void CloseCard();
        void LockCard();
        void UpdateCardID(int cardID);

        CardEntity GetCardEntity();
        
        void ActionOpenCard();
        void ActionCloseCard();
        void ActionLockCard();
    }
}